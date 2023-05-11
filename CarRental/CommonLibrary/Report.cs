namespace CarRental.Common;
public class ReportDetails
{
    public int UserId { get; set; }
    public DateTime LastLogged { get; set; }
    public Dictionary<DateTime, int> LogsNumberInDay { get; set; }
}

// List<ReportDetails> Report

/*
 [
    {
        "userid": 1,
        "lastlogged": (DateTime),
        "logsnumberindays": [
            "2023-05-20" : 2,
            "2023-05-21" : 0,
            "2023-05-22" : 1
        ]
    },
    {
        "userid": 2,
        "lastlogged": (DateTime),
        "logsnumberindays": [
            "2023-05-20" : 1,
            "2023-05-21" : 0,
            "2023-05-22" : 0
        ]
    }
]
 */
