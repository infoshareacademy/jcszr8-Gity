using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarRental.Common;
public class Term
{
    private DateTime _beginDate;
    private DateTime _endDate;

    public TimeSpan Interval => _endDate - _beginDate;

    [Display(Name = "Begin Date")]
    public DateTime BeginDate
    {
        get => _beginDate;
        set
        {
            var temp = TrimToWholeMinutes(value);
            _beginDate = temp < _endDate ? temp
                : throw new ArgumentException("Begin Date should be smaller than End Date.");
        }
    }

    [Display(Name = "End Date")]
    public DateTime EndDate
    {
        get => _endDate;
        set
        {
            var temp = TrimToWholeMinutes(value);
            _endDate = temp > _beginDate ? temp
                : throw new ArgumentException("End Date should be smaller than Begin Date.");
        }
    }

    public Term(DateTime beginDate, DateTime endDate)
    {
        var beginTrimmed = TrimToWholeMinutes(beginDate);
        var endTrimmed = TrimToWholeMinutes(endDate);
        if (beginTrimmed >= endTrimmed)
        {
            throw new ArgumentException("Begin Date should be smaller than End Date.");
        }
        _beginDate = beginTrimmed;
        _endDate = endTrimmed;
    }

    public DateTime TrimToWholeMinutes(DateTime dateTime)
    {
        return dateTime.AddSeconds(-dateTime.Second).AddMilliseconds(-dateTime.Millisecond);
    }

    public bool IsCollidingWith(Term term)
    {
        if (_endDate < term.BeginDate || _beginDate > term.EndDate)
            return false;
        return true;
    }
}
