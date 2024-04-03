using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airplanes
{
    public class NewsGenerator
    {
        List<object> newsProviders;
        List <IReportable> reportedObjects;
        List<Pair> check;
        public NewsGenerator(List <object> providers, List <IReportable> reported)
        {
            newsProviders = providers;
            reportedObjects = reported;
            check = new List<Pair>();
        }
        public string? GenerateNextNews()
        {
            int sizeNewsP = newsProviders.Count;
            int sizeReportedO = reportedObjects.Count;
            string nextNews;

            for (int i = 0; i < sizeNewsP; i++)
            {
                for (int j = 0; j < sizeReportedO; j++)
                {
                    Pair ind = new Pair(i, j);
                    if (check.Contains(ind))
                        continue;

                    var newsP = newsProviders[i];
                    var repO = reportedObjects[j];
                    if (newsP is Television t)
                        nextNews = t.providingNews(repO);
                    else if (newsP is Radio r)
                        nextNews = r.providingNews(repO);
                    else if (newsP is Newspaper n)
                        nextNews = n.providingNews(repO);
                    else
                        return null;

                    check.Add(ind);

                    return nextNews;
                }
            }
            return null;
        }
    }

    public class Pair
    {
        public int first { get; set; }
        public int second { get; set; }

        public Pair(int _first, int _second)
        {
            first = _first;
            second = _second;
        }
    }
}
