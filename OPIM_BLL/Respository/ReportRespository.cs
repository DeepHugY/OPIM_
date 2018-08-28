using OPIM_EntityFramework.QueryService;
using OPIM_EntityFramework.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPIM_BLL.Respository
{
    public class ReportRespository
    {
        private readonly RecordQueryService _recordQueryService;
        public ReportRespository()
        {
            this._recordQueryService = new RecordQueryService();
        }
        public List<AnnulRecordView> QueryAnnulRecordView(Guid memberShip, int year)
        {
            List<RecordView> listRemoveOtherYear = new List<RecordView>();
            var filter = _recordQueryService.Find(memberShip).ToList();
            int count = filter.Count;

            for (int i = 0; i < count; i++)
            {
                var years = int.Parse(filter[i].CreateOn.ToString().Substring(0, 4));
                if (years == year)
                {
                    listRemoveOtherYear.Add(filter[i]);
                }
            }
            var result = listRemoveOtherYear.GroupBy(p => p.TypesName).ToList();
            List<AnnulRecordView> list = new List<AnnulRecordView>();
            for (int i = 0; i < result.Count(); i++)
            {
                AnnulRecordView annulRecord = new AnnulRecordView();
                annulRecord.TypeName = result[i].Key;
                //得到某个类型某一年所有的记录
                List<RecordView> recordList = listRemoveOtherYear.Where(p => p.TypesName == result[i].Key).ToList();
                //对记录进行月份计算
                foreach (var item in recordList)
                {
                    string[] strArr = item.CreateOn.ToString().Split('/');
                    switch (strArr[1])
                    {
                        case "01":
                            annulRecord.January += item.Money;
                            break;
                        case "02":
                            annulRecord.February += item.Money;
                            break;
                        case "03":
                            annulRecord.March += item.Money;
                            break;
                        case "04":
                            annulRecord.April += item.Money;
                            break;
                        case "05":
                            annulRecord.May += item.Money;
                            break;
                        case "06":
                            annulRecord.June += item.Money;
                            break;
                        case "07":
                            annulRecord.July += item.Money;
                            break;
                        case "08":
                            annulRecord.August += item.Money;
                            break;
                        case "09":
                            annulRecord.September += item.Money;
                            break;
                        case "10":
                            annulRecord.October += item.Money;
                            break;
                        case "11":
                            annulRecord.November += item.Money;
                            break;
                        case "12":
                            annulRecord.December += item.Money;
                            break;
                        default:
                            break;
                    }
                }
                list.Add(annulRecord);
            }
            return list;
        }

        public AnnulRecordView GetTotal(List<AnnulRecordView> list)
        {
            AnnulRecordView view = new AnnulRecordView();
            view.TypeName = "总计";
            view.January = list.Sum(p => p.January);
            view.February = list.Sum(p => p.February);
            view.March = list.Sum(p => p.March);
            view.May = list.Sum(p => p.May);
            view.April = list.Sum(p => p.April);
            view.July = list.Sum(p => p.July);
            view.June = list.Sum(p => p.June);
            view.August = list.Sum(p => p.August);
            view.October = list.Sum(p => p.October);
            view.December = list.Sum(p => p.December);
            view.November = list.Sum(p => p.November);
            view.September = list.Sum(p => p.September);
            return view;
        }
    }
}
