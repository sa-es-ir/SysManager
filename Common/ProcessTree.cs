using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ProcessTreeMine
    {
        public ProcessTreeMine(string father, int from, int until, List<string> resultList)
        {
            fatherName = father;
            From = from;
            Until = until;
            for (int i = 0; i < resultList.Count; i++)
            {
                if (!resultList[i].StartsWith("  "))
                {
                    var index = resultList[i].IndexOf(" ");
                    if (index > 0)
                        resultList[i] = resultList[i].Substring(0, index);
                }
            }
            ResultList = resultList;
            IntiChild();
        }

        private void IntiChild()
        {
            ChildList = new List<ProcessTreeMine>();
            List<string> childs = GetChildOfProcess();
            ResultList.Distinct();
            for (int i = 0; i < ResultList.Count; i++)
            {
                if (!ResultList[i].StartsWith("  "))
                {
                    var index = ResultList[i].IndexOf(" ");
                    if (index > 0)
                        ResultList[i] = ResultList[i].Substring(0, index);
                }
            }
            ResultList.Distinct();
            int from = 0, until = 0;
            foreach (var item in childs)
            {
                for (int i = 0; i < ResultList.Count; i++)
                {
                    if (ResultList[i].StartsWith(item))
                    {
                        from = i;
                        break;
                    }
                }
                for (int i = from + 1; i < ResultList.Count; i++)
                {
                    if (ResultList[i].StartsWith("  "))
                    {
                        until = i;
                    }
                    else
                        break;
                }
                until = until == 0 ? from : until;
                if (from > 0)
                    ChildList.Add(new ProcessTreeMine(item, from, until, ResultList));

            }
        }

        private List<string> GetChildOfProcess()
        {
            var result = new List<string>();
            for (int i = From + 1; i <= Until; i++)
            {
                var item = string.Empty;
                if (ResultList[i].StartsWith("  "))
                    item = ResultList[i].Substring(2);
                ResultList[i] = item;
                if (!item.StartsWith("  "))
                {
                    var index = item.IndexOf(" ");
                    if (index > 0)
                        item = item.Substring(0, index);
                    result.Add(item);
                }
            }
            return result;
        }

        public List<string> ResultList;
        public string fatherName;
        public List<ProcessTreeMine> ChildList;
        public int From;
        public int Until;
    }
}
