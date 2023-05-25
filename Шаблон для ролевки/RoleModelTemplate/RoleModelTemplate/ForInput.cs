using System;
using System.Diagnostics.Metrics;

namespace RoleModelTemplate
{
    public enum eDocPosition
    {
        Focus,
        ExternalFiltr
    }

    public enum eTypeOfRoleScript
    {
        None,
        Buttons,
        ColumnsVisible,
        RowsVisible,
        ColumnsEditing,
        RowsEditing
    }

    public enum eItemType
    {
        Button,
        Column,
        Row
    }


    public class ForInput
    {


        public static void Main()
        {
            var inputAsStrings = ReadInputFile();
            GenerateScriptForRoleModel(inputAsStrings);
        }


        private static void GenerateScriptForRoleModel(string[] inputAsStrings)
        {
            // Забиваем случайным. Далее вычислим точный
            var typeOfRoleScript = eTypeOfRoleScript.None;

            // Вычисляем номера строк, в которых начинаются новые модули
            (int startOfRoles, int startOfStatuses, int starOfDocumentPosition) = GenerateNumbersOfStartModules(inputAsStrings, ref typeOfRoleScript);

            switch (typeOfRoleScript)
            {
                case eTypeOfRoleScript.Buttons:
                    {

                        // Эти проверки уже не нужны
                        {
                            //if (!inputAsStrings[0].ToLower().Contains("# кнопки"))
                            //{
                            //    Console.WriteLine("Произошла ошибка в 0-й строке");
                            //    return;
                            //}
                        }

                        int startOfButtons = 0;

                        if (startOfRoles == 0 || startOfStatuses == 0)
                        {
                            Console.WriteLine("Неправильно введены названия модулей.");
                            return;
                        }

                        Console.WriteLine(startOfButtons + " " + startOfRoles + " " + startOfStatuses);

                        var buttons = GenerateItems(inputAsStrings, typeOfRoleScript);
                        if (buttons is null)
                            return;

                        CheckItems(buttons);

                        var roles = GenerateRoles(inputAsStrings, startOfRoles);
                        if (roles is null)
                            return;

                        CheckRoles(roles);

                        if (!inputAsStrings[startOfStatuses + 1].Contains("enum"))
                        {
                            Console.WriteLine("Неправильно введен enum.");
                            return;
                        }
                        var words = inputAsStrings[startOfStatuses + 1].Split(' ');

                        //var startOfEnum = string.IndexOf(inputAsStrings[startOfStatuses + 1],
                        var nameOfEnum = GetNameOfEnum(words);

                        if (nameOfEnum is null)
                        {
                            Console.WriteLine("Неправильно введен enum.");
                            return;
                        }

                        var enumWithStatusses = new EnumFromInput(nameOfEnum);

                        FillEnum(enumWithStatusses, inputAsStrings, startOfStatuses);

                        CheckEnum(enumWithStatusses);

                        var documentPosition = inputAsStrings[starOfDocumentPosition + 1].ToLower().Contains("фокус") ? eDocPosition.Focus : eDocPosition.ExternalFiltr;

                        ForOutput.WriteOutput(buttons, roles, enumWithStatusses, documentPosition, typeOfRoleScript);
                    }
                    break;
                case eTypeOfRoleScript.ColumnsVisible:
                    {
                        // Эти проверки уже не нужны
                        {
                            //if (!inputAsStrings[0].ToLower().Contains("# колонки"))
                            //{
                            //    Console.WriteLine("Произошла ошибка в 0-й строке");
                            //    return;
                            //}
                        }

                        int startOfColumns = 0;

                        if (startOfRoles == 0 || startOfStatuses == 0 || starOfDocumentPosition == 0)
                        {
                            Console.WriteLine("Неправильно введены названия модулей.");
                            return;
                        }

                        Console.WriteLine(startOfColumns + " " + startOfRoles + " " + startOfStatuses);

                        var columns = GenerateItems(inputAsStrings, typeOfRoleScript);
                        if (columns is null)
                            return;

                        CheckItems(columns);

                        var roles = GenerateRoles(inputAsStrings, startOfRoles);
                        if (roles is null)
                            return;

                        CheckRoles(roles);

                        if (!inputAsStrings[startOfStatuses + 1].Contains("enum"))
                        {
                            Console.WriteLine("Неправильно введен enum.");
                            return;
                        }
                        var words = inputAsStrings[startOfStatuses + 1].Split(' ');

                        //var startOfEnum = string.IndexOf(inputAsStrings[startOfStatuses + 1],
                        var nameOfEnum = GetNameOfEnum(words);

                        if (nameOfEnum is null)
                        {
                            Console.WriteLine("Неправильно введен enum.");
                            return;
                        }

                        var enumWithStatusses = new EnumFromInput(nameOfEnum);

                        FillEnum(enumWithStatusses, inputAsStrings, startOfStatuses);

                        CheckEnum(enumWithStatusses);

                        var documentPosition = inputAsStrings[starOfDocumentPosition + 1].ToLower().Contains("фокус") ? eDocPosition.Focus : eDocPosition.ExternalFiltr;

                        ForOutput.WriteOutput(columns, roles, enumWithStatusses, documentPosition, typeOfRoleScript);
                    }
                    break;
                case eTypeOfRoleScript.RowsVisible:
                    {
                        int startOfColumns = 0;

                        if (startOfRoles == 0 || startOfStatuses == 0 || starOfDocumentPosition == 0)
                        {
                            Console.WriteLine("Неправильно введены названия модулей.");
                            return;
                        }

                        Console.WriteLine(startOfColumns + " " + startOfRoles + " " + startOfStatuses);

                        var columns = GenerateItems(inputAsStrings, typeOfRoleScript);
                        if (columns is null)
                            return;

                        CheckItems(columns);

                        var roles = GenerateRoles(inputAsStrings, startOfRoles);
                        if (roles is null)
                            return;

                        CheckRoles(roles);

                        if (!inputAsStrings[startOfStatuses + 1].Contains("enum"))
                        {
                            Console.WriteLine("Неправильно введен enum.");
                            return;
                        }
                        var words = inputAsStrings[startOfStatuses + 1].Split(' ');

                        //var startOfEnum = string.IndexOf(inputAsStrings[startOfStatuses + 1],
                        var nameOfEnum = GetNameOfEnum(words);

                        if (nameOfEnum is null)
                        {
                            Console.WriteLine("Неправильно введен enum.");
                            return;
                        }

                        var enumWithStatusses = new EnumFromInput(nameOfEnum);

                        FillEnum(enumWithStatusses, inputAsStrings, startOfStatuses);

                        CheckEnum(enumWithStatusses);

                        var documentPosition = inputAsStrings[starOfDocumentPosition + 1].ToLower().Contains("фокус") ? eDocPosition.Focus : eDocPosition.ExternalFiltr;

                        ForOutput.WriteOutput(columns, roles, enumWithStatusses, documentPosition, typeOfRoleScript);
                    }
                    break;
                case eTypeOfRoleScript.ColumnsEditing:
                    {
                        int startOfColumns = 0;

                        if (startOfRoles == 0 || startOfStatuses == 0 || starOfDocumentPosition == 0)
                        {
                            Console.WriteLine("Неправильно введены названия модулей.");
                            return;
                        }

                        Console.WriteLine(startOfColumns + " " + startOfRoles + " " + startOfStatuses);

                        var columns = GenerateItems(inputAsStrings, typeOfRoleScript);
                        if (columns is null)
                            return;

                        CheckItems(columns);

                        var roles = GenerateRoles(inputAsStrings, startOfRoles);
                        if (roles is null)
                            return;

                        CheckRoles(roles);

                        if (!inputAsStrings[startOfStatuses + 1].Contains("enum"))
                        {
                            Console.WriteLine("Неправильно введен enum.");
                            return;
                        }
                        var words = inputAsStrings[startOfStatuses + 1].Split(' ');

                        //var startOfEnum = string.IndexOf(inputAsStrings[startOfStatuses + 1],
                        var nameOfEnum = GetNameOfEnum(words);

                        if (nameOfEnum is null)
                        {
                            Console.WriteLine("Неправильно введен enum.");
                            return;
                        }

                        var enumWithStatusses = new EnumFromInput(nameOfEnum);

                        FillEnum(enumWithStatusses, inputAsStrings, startOfStatuses);

                        CheckEnum(enumWithStatusses);

                        var documentPosition = inputAsStrings[starOfDocumentPosition + 1].ToLower().Contains("фокус") ? eDocPosition.Focus : eDocPosition.ExternalFiltr;

                        ForOutput.WriteOutput(columns, roles, enumWithStatusses, documentPosition, typeOfRoleScript);
                    }
                    break;
                case eTypeOfRoleScript.RowsEditing:
                    {
                        int startOfColumns = 0;

                        if (startOfRoles == 0 || startOfStatuses == 0 || starOfDocumentPosition == 0)
                        {
                            Console.WriteLine("Неправильно введены названия модулей.");
                            return;
                        }

                        Console.WriteLine(startOfColumns + " " + startOfRoles + " " + startOfStatuses);

                        var columns = GenerateItems(inputAsStrings, typeOfRoleScript);
                        if (columns is null)
                            return;

                        CheckItems(columns);

                        var roles = GenerateRoles(inputAsStrings, startOfRoles);
                        if (roles is null)
                            return;

                        CheckRoles(roles);

                        if (!inputAsStrings[startOfStatuses + 1].Contains("enum"))
                        {
                            Console.WriteLine("Неправильно введен enum.");
                            return;
                        }
                        var words = inputAsStrings[startOfStatuses + 1].Split(' ');

                        //var startOfEnum = string.IndexOf(inputAsStrings[startOfStatuses + 1],
                        var nameOfEnum = GetNameOfEnum(words);

                        if (nameOfEnum is null)
                        {
                            Console.WriteLine("Неправильно введен enum.");
                            return;
                        }

                        var enumWithStatusses = new EnumFromInput(nameOfEnum);

                        FillEnum(enumWithStatusses, inputAsStrings, startOfStatuses);

                        CheckEnum(enumWithStatusses);

                        var documentPosition = inputAsStrings[starOfDocumentPosition + 1].ToLower().Contains("фокус") ? eDocPosition.Focus : eDocPosition.ExternalFiltr;

                        ForOutput.WriteOutput(columns, roles, enumWithStatusses, documentPosition, typeOfRoleScript);
                    }
                    break;
                default:
                    Console.WriteLine("Произошла ошибка при вычислении типа скрипта");
                    return;
            }
        }

        private static void CheckEnum(EnumFromInput enumWithStatusses)
        {
            Console.WriteLine(enumWithStatusses.Name);
            Console.WriteLine();

            foreach (var enumStatus in enumWithStatusses.Enums)
                Console.WriteLine(enumStatus);
            Console.WriteLine();
        }

        private static void FillEnum (EnumFromInput enumWithStatusses, string[] inputAsStrings, int startOfStatusses)
        {
            
            for (int i = startOfStatusses + 3; i < inputAsStrings.Length; i++)
            {
                if (inputAsStrings[i].Replace(" ", "").Replace("\r", "") == "}")
                    return;

                enumWithStatusses.Enums.Add(inputAsStrings[i].TrimStart().Split(' ')[0]);
            }
        }
        private static string GetNameOfEnum(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
                if (words[i] == "enum")
                    return words[i + 1].Replace(" ", "").Replace("\r", "");
            return null;
        }

        private static void CheckRoles(List<string> roles)
        {
            foreach (var role in roles)
                Console.WriteLine(role);
            Console.WriteLine();
        }
        
        private static List<string> GenerateRoles(string[] inputAsStrings, int startOfRoles)
        {
            List<string> roles = new List<string>();
            for (int counter = startOfRoles; counter < inputAsStrings.Length; counter++)
            {
                if (string.IsNullOrEmpty(inputAsStrings[counter + 1]) || inputAsStrings[counter + 1] == "\r")
                    return roles;
                else
                    roles.Add(inputAsStrings[counter + 1].Replace("\r", ""));
            }
            return null;
        }

        private static string[] ReadInputFile()
        {
            var inputAsFileInfo = new FileInfo(new DirectoryInfo(".").Parent?.Parent?.Parent?.Parent?.Parent?.FullName + "/input.txt");
            var inputAsStringReader = new StreamReader(inputAsFileInfo.FullName);
            var allTextFromInput = inputAsStringReader.ReadToEnd();
            return allTextFromInput.Split('\n');
        }

        private static List<Item> GenerateItems(string[] inputAsStrings, eTypeOfRoleScript typeOfRoleScript)
        {
            List<Item> items = new List<Item>();
            for (int counter = 0; counter < 100; counter++) 
            {
                // counter + 1, потому что 0-я строка - это "# Кнопки" или "#Колонки"
                if (string.IsNullOrEmpty(inputAsStrings[counter + 1]) || inputAsStrings[counter + 1] == "\r" )
                    return items;
                else
                {
                    var splittedStringForItem = inputAsStrings[counter + 1].Split('-');

                    if (splittedStringForItem.Length != 2)
                    {
                        Console.WriteLine("Неправильно оформлена строка №" + counter + 2);
                        return null;
                    }

                    int newItemId = Convert.ToInt32(splittedStringForItem[0].Replace(" ", ""));
                    string newItemName = splittedStringForItem[1].TrimStart().Replace("\r", "");
                    Item column = new Item(newItemId, newItemName, ConvertTypeOfRoleScriptToItemType(typeOfRoleScript));
                    items.Add(column);
                }
            }
            return null;
        }

        private static eItemType ConvertTypeOfRoleScriptToItemType(eTypeOfRoleScript typeOfRoleScript)
        {
            switch (typeOfRoleScript)
            {
                case eTypeOfRoleScript.Buttons: 
                    return eItemType.Button;
                case eTypeOfRoleScript.ColumnsVisible:
                case eTypeOfRoleScript.ColumnsEditing:
                    return eItemType.Column;
                default:
                    return eItemType.Row;
            }
        }
        private static (int, int, int) GenerateNumbersOfStartModules(string[] inputAsStrings, ref eTypeOfRoleScript typeOfRoleScript)
        {
            var a = inputAsStrings[0].ToLower();
            switch (inputAsStrings[0].ToLower())
            {
                case "# колонки видимость\r":
                    typeOfRoleScript = eTypeOfRoleScript.ColumnsVisible; break;
                case "# кнопки\r":
                    typeOfRoleScript = eTypeOfRoleScript.Buttons; break;
                case "# строки видимость\r":
                    typeOfRoleScript = eTypeOfRoleScript.RowsVisible; break;
                case "# колонки редактирование\r":
                    typeOfRoleScript = eTypeOfRoleScript.ColumnsEditing; break;
                case "# строки редактирование\r":
                    typeOfRoleScript = eTypeOfRoleScript.RowsEditing; break;
            }

            switch (typeOfRoleScript)
            {
                case eTypeOfRoleScript.Buttons:
                case eTypeOfRoleScript.ColumnsVisible:
                case eTypeOfRoleScript.RowsVisible:
                case eTypeOfRoleScript.ColumnsEditing:
                case eTypeOfRoleScript.RowsEditing:
                    {
                        int startOfRoles = 0;
                        int startOfStatuses = 0;
                        int startOfDocumentPosition = 0;
                        for (int i = 0; i < inputAsStrings.Length; i++)
                        {
                            if (inputAsStrings[i].ToLower().Contains("# роли"))
                                startOfRoles = i;
                            else if (inputAsStrings[i].ToLower().Contains("# статусы документа"))
                                startOfStatuses = i;
                            else if (inputAsStrings[i].ToLower().Contains("# положение документа"))
                                startOfDocumentPosition = i;
                        }

                        return (startOfRoles, startOfStatuses, startOfDocumentPosition);
                    }
                    break;
            }
            return (0, 0, 0);

        }

        private static void CheckItems(List<Item> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item.ID + " " + item.NameInETOS);
            }
            Console.WriteLine();
        }
    }

    public class Item
    {
        public string NameInETOS { get; set; }
        public int ID { get; set; }
        public string VariableName { get; set; }
        public eItemType ItemType { get; set; }


        public Item(int id, string nameInETOS, eItemType itemType) 
        {
            ID = id;
            NameInETOS = nameInETOS;
            VariableName = ToString(itemType)+ id.ToString();
            ItemType = itemType;
        }

        public string ToString(eItemType itemType)
        {
            switch (itemType)
            {
                case eItemType.Column: return "column";
                case eItemType.Row: return "row";
                default: return "button";
            }
        }
    }

    public class EnumFromInput
    {
        public List<string> Enums = new List<string>();

        public string Name { get; set; }

        public EnumFromInput(string name)
        {
            Name = name;
        }
    }
}