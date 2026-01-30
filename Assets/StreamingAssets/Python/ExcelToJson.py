import pandas as pd
import json
import os


def convert_cards_excel_to_json(excel_file,sheet, output_file=None):
    # 1. 读取Excel
    df = pd.read_excel(excel_file, header=None,sheet_name=sheet)
    #print(df.iloc[0,2])
    # 2. 清理前4列
    for col in [0, 1, 2, 3]:
        if col in df.columns:
            df[col] = df[col].astype(str).str.strip().replace('nan', '')

    rows, cols = df.shape
    print(rows)
    VALUE_START_COL = 4

    # 3. 获取根结构体名称（A1）
    root_name = df.iloc[0, 0] if df.iloc[0, 0] else ""
    print(f"🎯 根结构体: '{root_name}'")

    # 4. 识别所有结构体范围（基于A列）
    structures = {}
    struct_rows = []

    for i in range(0,rows):
        a_val = str(df.iloc[i, 0]).strip()
        if a_val:
            struct_rows.append(i)

    if not struct_rows:
        raise ValueError("❌ A列中未找到任何结构体标记")

    for idx, start in enumerate(struct_rows):
        struct_name = str(df.iloc[start, 0]).strip()
        end = struct_rows[idx + 1] if idx + 1 < len(struct_rows) else rows
        structures[struct_name] = {'start_row': start, 'end_row': end}
        print(f"🏗️ 结构体 '{struct_name}': 行 {start}-{end-1}")

    # 5. 确保根结构体存在
    if root_name not in structures:
        structures[root_name] = {'start_row': 0, 'end_row': rows}
        print(f"⚠️ 手动添加根结构体 '{root_name}'")

    # 6. 读取数值函数
    def read_value(row_idx, col_idx):
        value = df.iloc[row_idx, col_idx]
        value_type = str(df.iloc[row_idx, 3]).strip()

        # 空值处理（根据类型返回合适的默认值）
        if pd.isna(value) or str(value).strip() == '':
            if 'list' in value_type:
                return []
            elif value_type == 'string':
                return ''
            elif value_type == 'int':
                return 0
            else:
                return 0.0

        value_str = str(value).strip()

        # 列表类型（标注"list[int]"或"list[float]"等）
        if 'list' in value_type:
            value_str = value_str.strip('[]')
            if value_str:
                items = [x.strip() for x in value_str.split(',')]
                if 'int' in value_type:
                    return [int(float(x)) for x in items if x]
                else:
                    return [float(x) for x in items if x]
            return []

        # **新增：字符串类型（直接返回原字符串）**
        if value_type == 'string':
            return value_str

        # 原有标量逻辑
        return int(float(value)) if value_type == 'int' else float(value)

    # 7. 判断B列是否为子结构体定义
    def is_sub_struct_def(row_idx, end_row):
        """B列是子结构体名的条件：B有值且下一行C有值"""
        if row_idx >= end_row - 1:
            return False

        b_val = str(df.iloc[row_idx, 1]).strip()
        if not b_val:
            return False

        next_b_val = str(df.iloc[row_idx + 1, 1]).strip()
        if next_b_val:
            return False

        next_c_val = str(df.iloc[row_idx + 1, 2]).strip()
        return bool(next_c_val)

    # 8. 递归读取结构体（核心修复）
    def read_structure(struct_name, col_idx):
        if struct_name not in structures:
            return {}

        start = structures[struct_name]['start_row']
        end = structures[struct_name]['end_row']
        obj = {}
        i = start + 1

        while i < end:
            a_val = str(df.iloc[i, 0]).strip()
            b_val = str(df.iloc[i, 1]).strip()
            c_val = str(df.iloc[i, 2]).strip()

            # 嵌套结构体（A列有不同值）
            if a_val and a_val != struct_name and a_val in structures:
                sub_data = read_structure(a_val, col_idx)
                if sub_data:
                    obj[a_val] = sub_data
                i += 1
                continue

            # 情况1: B列是子结构体定义（如weapon行）
            if b_val and is_sub_struct_def(i, end):
                sub_obj = {}
                j = i + 1
                # 收集所有子属性（直到C列空或B列有值）
                while j < end:
                    next_c = str(df.iloc[j, 2]).strip()
                    next_b = str(df.iloc[j, 1]).strip()

                    if not next_c or next_b:  # C空或B有值，结束
                        break

                    sub_prop = next_c
                    sub_obj[sub_prop] = read_value(j, col_idx)
                    j += 1

                obj[b_val] = sub_obj
                i = j  # 跳过已处理的子属性行
                continue

            # 情况2: 普通属性（A空, B有值, C空）
            if not a_val and b_val and not c_val:
                obj[b_val] = read_value(i, col_idx)

            # 情况3: 子属性行（理论上不应直接出现在顶层）
            # 已在情况1中处理

            i += 1

        return obj if obj else None

    # 9. 遍历每张卡片
    result = {root_name: []}
    num_cards = cols - VALUE_START_COL

    for card_col in range(VALUE_START_COL, cols):
        if pd.isna(df.iloc[1, card_col]) or str(df.iloc[1, card_col]).strip() == '':
            continue

        card_data = read_structure(root_name, card_col)
        if card_data:
            result[root_name].append(card_data)

    return result

def convert(file,sheet,output):
    try:
        json_data = convert_cards_excel_to_json(
            file,
            sheet
        )
        root_name = list(json_data.keys())[0]
        output_file = output
        with open(output_file, 'w', encoding='utf-8') as f:
            json.dump(json_data, f, indent=2, ensure_ascii=False)

        print(f"\n✅ 转换成功！")
        print(f"📄 共 {len(json_data[root_name])} 个记录")
        print(f"💾 保存到: {os.path.abspath(output_file)}")

    except Exception as e:
        print(f"❌ 错误: {e}")
        import traceback

        traceback.print_exc()
# ========== 使用示例 ==========
if __name__ == '__main__':
    convert(r'Excel/Config.xlsx', "hero", f"../Config/Config_Hero.json")
    convert(r'Excel/Config.xlsx',"card",f"../Config/Config_Card.json")
    convert(r'Excel/Config.xlsx', "weapon", f"../Config/Config_Weapon.json")
    convert(r'Excel/Config.xlsx',"enemy", f"../Config/Config_Enemy.json")
    convert(r'Excel/Config.xlsx', "level_0", f"../Config/Config_Level_0.json")
    convert(r'Excel/Config.xlsx', "level_1", f"../Config/Config_Level_1.json")
    convert(r'Excel/Config.xlsx', "level_2", f"../Config/Config_Level_2.json")
    convert(r'Excel/Config.xlsx', "level_3", f"../Config/Config_Level_3.json")
    convert(r'Excel/Config.xlsx', "level_4", f"../Config/Config_Level_4.json")
    convert(r'Excel/Config.xlsx', "drop", f"../Config/Config_Drop.json")
    convert(r'Excel/Config.xlsx', "skill", f"../Config/Config_Skill.json")
    convert(r'Excel/Config.xlsx', "cardDes", f"../Config/D/Config_D_card.json")
    convert(r'Excel/Config.xlsx',"weaponDes", f"../Config/D/Config_D_weapon.json")
    convert(r'Excel/Config.xlsx', "enemyDes", f"../Config/D/Config_D_enemy.json")
    convert(r'Excel/Config.xlsx', "skillDes", f"../Config/D/Config_D_skill.json")
