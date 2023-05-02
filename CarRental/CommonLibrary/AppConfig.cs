using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Common;
public static class AppConfig
{   
    // For Customer
    public const int CustomerFirstNameMaxLength = 30;
    public const int CustomerLastNameMaxLength = 50;
    public const int EmailMaxLength = 100;
    public const int PeselLength = 11;
    public const int PhoneNumberMinLength = 10;
    public const int PhoneNumberMaxLength = 50;


    // For Cars
    public const int CarMakeMaxLength = 20;
    public const int CarModelMaxLength = 20;
    public const int CarLicencePlateNumberMinLength = 3;
    public const int CarLicencePlateNumberMaxLength = 10;
    public const int CarColorMaxLength = 20;
    public const int CarYearMinValue = 2000;
    public static readonly int CarYearMaxValue = DateTime.Now.Year;
    public const int CarDescriptionMaxLength = 1000;
    public const int CarPricePerDayMinValue = 0;
    public const int CarPricePerDayMaxValue = 500;

    // For Rentals
    public const int RentalCommentMaxLength = 500;
    public const int RentalMinDays = 1;
    public const int RentalMaxDays = 90;
    public const int RentalMaxLimitOfRentals = 5;



    // For Buckets
    public const int MaxLimitOfBuckets = 10;
    public const int BucketNameMaxLength = 100;
    public const int BucketDescriptionMaxLength = 500;
    public const string BucketDefaultColor = "#8b4513"; //brown color #8b4513

    public const int MinNumberOfTasks = 0;
    public const int MaxNumberOfTasks = 40;
    public const int DefaultMaxNumberOfTasks = 15;

    public const int TaskTitleMaxLength = 100;
    public const int TaskDescriptionMaxLength = 500;

    public const int AssigneeAutoSearchFromNChars = 3;
    public const int AssigneeNameMaxLenght = 100;
    public const int AssigneesMaxLimitForTask = 5;

}
