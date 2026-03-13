using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace USBCopyer
{
    public class FolderRuleHelper
    {
        public FolderRuleReturn FolderRuleDeserialize(string FolderRule)
        {
            List<FolderRulePart> dirParts = new List<FolderRulePart>();
            string dirRule = FolderRule;
            bool isNextEscape = false;
            try
            {
                for (int charIndex = 0; charIndex < dirRule.Length; charIndex++)
                {
                    //[xxx]=1,[yyy]=2
                    //"foo@""[xxx]"bar[yyy]"
                    //foo"1bar[yyy]
                    if (dirRule[charIndex] == '"')
                    {
                        if (charIndex == 0 || (charIndex > 0 & dirRule[charIndex - 1] != '@')) //如果第一个字符是引号或者引号前一个字符不是转义
                        {//字符串组成部分开始
                            StringBuilder stringPartSB = new StringBuilder();
                            while (true)
                            {
                                charIndex++;
                                //情况1 本字符不是@ 下一个字符不是" :正常添加字符
                                //情况2 本字符是@ 下一个字符是" :添加"
                                //情况3 本字符是@ 下一个字符不是" :添加@
                                //特殊情况 @@@@@foobar 要转换为 @@@foobar (原表达式第1、3个@为转义，第2、4个@被转义为普通字符，第5个@本身是普通字符)
                                if (!isNextEscape & dirRule[charIndex] == '"') //如果本字符为引号且前一个字符不是转义
                                { break; }//该字符串组成部分结束

                                if (!isNextEscape & (dirRule[charIndex] == '@' & (dirRule[charIndex + 1] == '"' || dirRule[charIndex + 1] == '@'))) //如果本字符为转义且后一个字符是"或@
                                {
                                    //直接跳过本字符
                                    isNextEscape = true;
                                }
                                else//如果不是
                                {
                                    stringPartSB.Append(dirRule[charIndex]);//在本部分字符串末尾插入该字符
                                    isNextEscape = false;
                                }
                            }
                            dirParts.Add(new FolderRulePart { type=FolderRulePart.PartType.String, content = (string)stringPartSB.ToString() });//新增并添加一条路径组成部分到数组
                        }
                    }
                    else if (dirRule[charIndex] == '[')
                    {
                        if (charIndex == 0 || (charIndex > 0 & dirRule[charIndex - 1] != '@')) //如果第一个字符是[或者[前一个字符不是转义
                        {//内插组成部分开始
                            StringBuilder interpolationPartSB = new StringBuilder();
                            while (true)
                            {
                                charIndex++;
                                if (!isNextEscape & dirRule[charIndex] == ']') //如果本字符为]且前一个字符不是转义
                                { break; }//该内插组成部分结束

                                interpolationPartSB.Append(dirRule[charIndex]);//在本部分字符串末尾插入该字符

                            }

                            //FolderRulePart.InterpolationType interpolationType;
                            //if(!Enum.TryParse(interpolationPartSB.ToString(), true,out interpolationType))
                            //{
                            //    throw new Exception("无匹配");
                            //    //interpolationType = FolderRulePart.InterpolationType.Default; 
                            //}

                            dirParts.Add(new FolderRulePart {type=FolderRulePart.PartType.Interpolation, content = interpolationPartSB.ToString()});//新增并添加一条路径组成部分到数组

                        }

                    }
                }

                return new FolderRuleReturn { isSuccess = true, folderNameParts = dirParts };
            }
            catch (Exception)
            {
                return new FolderRuleReturn { isSuccess = false };
            }


        }


        public class FolderRulePart
        {
            //public dynamic content { get; set; }

            public string content { get; set; }

            public PartType type {
                //get
                //{
                //    if (content.GetType() == typeof(string))
                //    {
                //        return PartType.String;
                //    }
                //    else
                //    if (content.GetType() == typeof(InterpolationType))
                //    {
                //        return PartType.Interpolation;
                //    }
                //    else { return PartType.Default; }
                //}
                get;set;
            }
            public enum PartType
            {
                String,
                Interpolation,
                Default
            }


            //public enum InterpolationType
            //{
            //    //[name]卷标
            //    //[serial]磁盘序列号
            //    //[letter]盘符
            //    //[type]磁盘描述
            //    //[fs]文件系统
            //    Name,
            //    Serial,
            //    Letter,
            //    Type,
            //    Fs,
            //    Default
            //}

        }
        public class FolderRuleReturn
        {
            public bool isSuccess { get; set; }
            public List<FolderRulePart> folderNameParts { get; set; }
        }
    }
}
