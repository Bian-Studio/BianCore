﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace BianCore.Tools
{
    public static class Downloads
    {
        private static List<string> DList = new List<string>();
        private static List<string> DPath = new List<string>();
        public static void AddDList(string link, string path)
        {
            DPath.Add(path);
            DList.Add(link);
        }
        public static void ClearList()
        {
            DPath.Clear();
            DList.Clear();
        }

        public static async Task Async(string Url = null, string save = null, bool model = true)
        {
            using (var web = new WebClient())
            {
                if (model == false)
                {
                    for (int i = 0; i < DList.Count; i++)
                    {
                        if (!Directory.Exists(Path.GetDirectoryName(DPath[i])))
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(DPath[i]));
                        }
                        await web.DownloadFileTaskAsync(DList[i], DPath[i]);
                    }
                    ClearList();
                }
                else
                {
                    if (!Directory.Exists(Path.GetDirectoryName(save)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(save));
                    }
                    await web.DownloadFileTaskAsync(Url, save);
                }
            }
        }

        public static void Plan1(string Url = null, string save = null, bool model = true)
        {
            using (var web = new WebClient())
            {
                if (!Directory.Exists(Path.GetDirectoryName(save)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(save));
                }
                if (model == false)
                {
                    for (int i = 0; i < DList.Count; i++)
                    {
                        web.DownloadFile(DList[i], DPath[i]);
                    }
                    ClearList();
                }
                else { web.DownloadFile(Url, save); }
            }
        }
    }
}
