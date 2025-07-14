using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ECommons.Logging;

namespace WrathCombo.Resources.Dictionary.Chinese
{
    public static class SkillTranslationTableGenerator
    {
        private static readonly Dictionary<string, string> JobNameMapping = new()
        {
            { "AST", "占星术士" },
            { "BLM", "黑魔法师" },
            { "BRD", "吟游诗人" },
            { "DNC", "舞者" },
            { "DRG", "龙骑士" },
            { "DRK", "暗黑骑士" },
            { "GNB", "枪刃士" },
            { "MCH", "机工士" },
            { "MNK", "武僧" },
            { "NIN", "忍者" },
            { "PAL", "骑士" },
            { "PLD", "骑士" },
            { "RDM", "赤魔法师" },
            { "RPR", "钐镰客" },
            { "SAM", "武士" },
            { "SCH", "学者" },
            { "SGE", "贤者" },
            { "SMN", "召唤师" },
            { "VPR", "蝰蛇剑士" },
            { "WAR", "战士" },
            { "WHM", "白魔法师" },
            { "BLU", "青魔法师" },
            { "DOL", "采集职业" },
            { "DOH", "制作职业" },
            { "PCT", "青魔法师" },
            { "Common", "通用技能" },
            { "Bozja", "博兹雅技能" },
            { "Variant", "变体技能" }
        };
        public static void GenerateSkillTranslationTable()
        {
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = Path.Combine(desktopPath, "WrathCombo技能对照表.md");

                using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    writer.WriteLine("# WrathCombo 技能名称中英文对照表");
                    writer.WriteLine();
                    writer.WriteLine($"生成时间: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                    writer.WriteLine();
                    writer.WriteLine("## 说明");
                    writer.WriteLine();
                    writer.WriteLine("此对照表包含游戏中所有职业的技能名称中英文对照。");
                    writer.WriteLine("技能名称通过游戏客户端获取，确保准确性。");
                    writer.WriteLine();
                    writer.WriteLine("---");
                    writer.WriteLine();

                    // 获取所有技能文件
                    var skillFiles = GetSkillFiles();
                    
                    foreach (var skillFile in skillFiles.OrderBy(f => f.Key))
                    {
                        var jobName = skillFile.Key;
                        var skills = skillFile.Value;
                        
                        if (skills.Any())
                        {
                            writer.WriteLine($"## {GetJobDisplayName(jobName)} ({jobName})");
                            writer.WriteLine();
                            
                            writer.WriteLine("| 英文名称 | 中文名称 |");
                            writer.WriteLine("|---------|---------|");
                            
                            foreach (var skill in skills.OrderBy(s => s.Key))
                            {
                                writer.WriteLine($"| {skill.Key} | {skill.Value} |");
                            }
                            
                            writer.WriteLine();
                            writer.WriteLine("---");
                            writer.WriteLine();
                        }
                    }
                }

                PluginLog.Information($"技能对照表已生成到桌面: WrathCombo技能对照表.md");
            }
            catch (Exception ex)
            {
                PluginLog.Error($"生成技能对照表时发生错误: {ex.Message}\n{ex.StackTrace}");
            }
        }

        private static Dictionary<string, IEnumerable<KeyValuePair<string, string>>> GetSkillFiles()
        {
            var skillFiles = new Dictionary<string, IEnumerable<KeyValuePair<string, string>>>();
            var skillNamespace = "WrathCombo.Resources.Dictionary.Chinese.Description";
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var skillTypes = assembly.GetTypes()
                .Where(t => t.Namespace == skillNamespace && t.Name.EndsWith("Skills"))
                .ToList();

            foreach (var skillType in skillTypes)
            {
                try
                {
                    var jobName = skillType.Name.Replace("Skills", "");
                    var getSkillsMethod = skillType.GetMethod("GetSkills");
                    if (getSkillsMethod != null)
                    {
                        // 静态方法调用，无需实例化
                        var skills = (IEnumerable<KeyValuePair<string, string>>)getSkillsMethod.Invoke(null, null);
                        skillFiles[jobName] = skills;
                    }
                }
                catch (Exception ex)
                {
                    PluginLog.Warning($"获取技能文件 {skillType.Name} 时发生错误: {ex.Message}");
                }
            }
            return skillFiles;
        }

        private static string GetJobDisplayName(string jobName)
        {
            return JobNameMapping.TryGetValue(jobName, out var displayName) ? displayName : jobName;
        }
    }
} 