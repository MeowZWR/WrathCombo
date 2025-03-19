using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ECommons.Logging;

namespace WrathCombo.Resources.Dictionary.Chinese
{
    public static class DictionaryDebugger
    {
        // 存储所有未被替换的英文文本
        private static readonly HashSet<string> _unreplacedTexts = new();

        // 存储所有未被使用的键值对
        private static readonly HashSet<string> _unusedKeys = new();

        // 存储所有已使用的键值对
        private static readonly HashSet<string> _usedKeys = new();

        // 初始时加载所有键值对
        public static void Initialize()
        {
            // 初始化时记录所有键
            foreach (var pair in ReplacementsDictionary.Replacements)
            {
                _unusedKeys.Add(pair.Key);
            }

            PluginLog.Information($"键值对调试器初始化完成，加载了 {_unusedKeys.Count} 个键值对");
        }

        // 在TextReplacer中每次替换后调用
        public static void RecordUsedKey(string key)
        {
            if (_unusedKeys.Contains(key))
            {
                _unusedKeys.Remove(key);
                _usedKeys.Add(key);
            }
        }

        // 记录未替换的文本
        public static void RecordUnreplacedText(string text)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                _unreplacedTexts.Add(text);
            }
        }

        // 导出调试信息到文件
        public static void ExportDebugFile()
        {
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = Path.Combine(desktopPath, "WrathDictionaryDebug.txt");

                using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    writer.WriteLine("WrathCombo中文翻译键值对调试文件");
                    writer.WriteLine($"生成时间: {DateTime.Now}");
                    writer.WriteLine($"词典总数: {ReplacementsDictionary.Replacements.Count}");
                    writer.WriteLine($"已使用键值对: {_usedKeys.Count}");
                    writer.WriteLine($"未使用键值对: {_unusedKeys.Count}");
                    writer.WriteLine($"未替换文本总数: {_unreplacedTexts.Count}");
                    writer.WriteLine();

                    // 输出未被替换的英文文本
                    writer.WriteLine("=== 未被替换的英文文本 ===");
                    foreach (var text in _unreplacedTexts.OrderBy(t => t))
                    {
                        writer.WriteLine($"\"{text}\"");
                    }
                    writer.WriteLine();

                    // 输出未被使用的键值对
                    writer.WriteLine("=== 未被使用的键值对 ===");
                    foreach (var key in _unusedKeys.OrderBy(k => k))
                    {
                        writer.WriteLine($"\"{key}\" => \"{ReplacementsDictionary.Replacements[key]}\"");
                    }

                    // 输出重复键的日志
                    writer.WriteLine();
                    writer.WriteLine("=== 重复键日志 ===");
                    writer.Write(ReplacementsDictionary.GetDuplicateKeysLog());
                }

                PluginLog.Information($"键值对调试文件已生成到桌面: WrathDictionaryDebug.txt");
            }
            catch (Exception ex)
            {
                PluginLog.Error($"生成键值对调试文件时发生错误: {ex.Message}\n{ex.StackTrace}");
            }
        }
    }
}