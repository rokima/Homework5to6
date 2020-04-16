using Abc.Data.Common;

namespace Abc.Data.Quantity
{
    public abstract class CommonTermData: PeriodData
    {
        public string MasterId { get; set; } //hoiab id kiirusele
        public string TermId { get; set; } //term peab näitame meile pikkusele, teine term peab näitama kiirusele
        public int Power { get; set;}  //aste mis näitab mis astmes on mingi termiga jagamine
    }
}
