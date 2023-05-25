using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleModelTemplate
{
    internal class ForOutput
    {
        public static void WriteOutput(List<Item> buttons, List<string> roles, EnumFromInput enumWithStatusses,
            eDocPosition docPosition, eTypeOfRoleScript typeOfRoleScript)
        {
            List<string> output = new List<string>();

            GenerateOutput(buttons, roles, enumWithStatusses, docPosition, typeOfRoleScript, output);

            WriteInOutPutFile(output);
        }

        private static void GenerateOutput(List<Item> buttons, List<string> roles, EnumFromInput enumWithStatusses,
            eDocPosition docPosition, eTypeOfRoleScript typeOfRoleScript, List<string> output)
        {
            switch (typeOfRoleScript)
            {
                case eTypeOfRoleScript.Buttons:
                    output.Add("// Далее идёт шаблон для скрипта \"Выбор 1\" для видимости кнопок");
                    break;
                case eTypeOfRoleScript.ColumnsVisible:
                    output.Add("// Далее идёт шаблон для скрипта \"Загрзка 3.2.\"");
                    break;
                case eTypeOfRoleScript.RowsVisible:
                    output.Add("// Далее идёт шаблон для скрипта \"Загрзка 1\"");
                    break;
                case eTypeOfRoleScript.ColumnsEditing:
                    output.Add("// Далее идёт шаблон для скрипта \"Выбор 1\" для редактирования колонок");
                    break;
                case eTypeOfRoleScript.RowsEditing:
                    output.Add("// Далее идёт шаблон для скрипта \"Выбор 1\" для редактирования строк");
                    break;
            }
            output.Add("");
            GenerateInnitializationItems(buttons, output, typeOfRoleScript);
            AddSupportString(output, docPosition);

            if (roles.Contains("ugp53"))
                roles.Remove("ugp53");

            GenerateTryBlock(output, buttons, roles, enumWithStatusses);
            GenerateFinallyBlock(output, buttons, typeOfRoleScript);
            output.Add("return null;");
        }


        private static void GenerateFinallyBlock(List<string> output, List<Item> items, eTypeOfRoleScript typeOfRoleScript)
        {
            output.Add("finally");
            output.Add("{");
            foreach (var item in items)
            {
                switch (typeOfRoleScript)
                {
                    case eTypeOfRoleScript.Buttons:
                        output.Add("    pSOANR.ctrlManagerData?.SetCommandToolBarButtonItem8Visible(" +
                            item.ID + ", " + item.VariableName + ");  // " + item.NameInETOS);
                        break;
                    case eTypeOfRoleScript.ColumnsVisible:
                        output.Add("    pSOANR.ctrlManagerData.SetActiveViewColumn4Visible(" +
                            item.ID + ", 0, " + item.VariableName + ");  // " + item.NameInETOS);
                        break;
                    case eTypeOfRoleScript.RowsVisible:
                        {
                            output.Add("    if (" + item.VariableName + ")");
                            output.Add("        pSOANR.pCRMDK.SetRowVisibleInPropertyByID(" + item.ID + 
                                ", eRowUsingType_TreeView.VisibleRow, eRowUsingType_DiagramChartSheduler.Use);");
                            output.Add("    else");
                            output.Add("        pSOANR.pCRMDK.SetRowVisibleInPropertyByID(" + item.ID +
                                ", eRowUsingType_TreeView.HideRow, eRowUsingType_DiagramChartSheduler.NotUse);");
                            output.Add("");
                        }
                        break;
                    case eTypeOfRoleScript.ColumnsEditing:
                        output.Add("    ((ManagerDataControl)pSOANR.ctrlManagerData).SetActiveViewColumn4DisableEditor(" +
                            item.ID + ", 0, !" + item.VariableName + ");");
                        break;
                    case eTypeOfRoleScript.RowsEditing:
                        output.Add("   pSOANR.pCRMDK.SetRowDisableEditorInPropertyByID(" +
                            item.ID + ", !" + item.VariableName + ");");
                        break;

                }
            }
            output.Add("}");
        }

        private static void GenerateTryBlock(List<string> output, List<Item> buttons, 
            List<string> roles, EnumFromInput enumWithStatusses)
        {
            output.Add("try");
            output.Add("{");

            GenerateAdminBlock(output, buttons);

            for (int i = 0; i < roles.Count; i++)
                GenerateBlockByRole(output, roles[i], enumWithStatusses);
            output.Add("}");

        }

        private static void GenerateBlockByRole(List<string> output, string role, EnumFromInput enumWithStatusses)
        {
            output.Add("    else if (lstKeyNum.Contains(\"" + role + "\".ToLower()))");
            output.Add("    {");
            output.Add("        switch (pPaper.iStatusC)");
            output.Add("        {");
            foreach (var anotherEnum in enumWithStatusses.Enums)
            {
                output.Add("            case (long)" + enumWithStatusses.Name + "." +  anotherEnum + ":");
                output.Add("                {");
                output.Add("");
                output.Add("                }");
                output.Add("                break;");
                output.Add("");
            }

            output.Add("        }");
            output.Add("    }");
            output.Add("");
        }

        private static void GenerateAdminBlock(List<string> output, List<Item> items)
        {
            output.Add("    if (lstKeyNum.Contains(\"ugp53\"))");
            output.Add("    {");
            foreach (var item in items)
                output.Add("        " + item.VariableName + " = true;");
            output.Add("    }");
            output.Add("");
        }

        private static void AddSupportString(List<string> output, eDocPosition docPosition)
        {
            output.Add("");
            output.Add(@"// Временная мера, после обновления ЭТОСа скорее всего можно будет убрать. (Лыско_ДОПИС)");
            output.Add(@"routeArg.pUser = (tUser)routeArg.pUser.ReadObjectAsNew(eReadMode.All, routeArg);");
            output.Add("");
            output.Add(@"// Все роли пользователя");
            output.Add("List<string> lstKeyNum = routeArg.pUser.GetUserGroupProfileKod();");
            output.Add("");

            if (docPosition == eDocPosition.Focus)
                output.Add("if (pSOANR.pFocusedObject is not tPaper pPaper)");
            else
                output.Add("if (pSOANR.pObjectFromExternal4Filtr is not tPaper pPaper");
            output.Add("    return null;");
            output.Add("");
        }


        private static void GenerateInnitializationItems(List<Item> items,
            List<string> output, eTypeOfRoleScript typeOfRoleScript)
        {
            var lstBools = new List<string>();
            foreach (var item in items)
            {
                var stringForItem = "bool " + item.VariableName;
                lstBools.Add(stringForItem);
                stringForItem += " = false;  ";
                stringForItem += "//  " + item.NameInETOS;
                output.Add(stringForItem);
            }
        }

        private static void WriteInOutPutFile(List<string> output)
        {
            var outputAsFileInfo = new FileInfo(new DirectoryInfo(".").Parent?.Parent?.Parent?.Parent?.Parent?.FullName + "/output.cs");
            var outputAsStringWriter = new StreamWriter(outputAsFileInfo.FullName);

            foreach (var str in output)
                outputAsStringWriter.Write(str + "\r");
            outputAsStringWriter.Close();
        }
    }
}
