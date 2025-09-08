/*
 * Copyright (c) 2025 Arpita
 * All rights reserved.
 *
 * This source code is licensed under the terms specified by the owner.
 */
using OpenQA.Selenium;

namespace InterfaceClass
{
    /// <summary>
    /// Interface for "View by" and "Filter results" section
    /// on the booking page. Defines actions and state verifications.
    /// </summary>
    public interface IBookingFilters
    {
        // View By actions
        void ClickPrice();
        void ClickCalendar();
        void ClickSchedule();

        // Filter Results actions
        void ClickNonstop();
        void ClickOneStop();
        void ClickTwoPlusStops();

        // State checkers
        bool IsPriceSelected();
        bool IsCalendarSelected();
        bool IsScheduleSelected();

        bool IsNonstopSelected();
        bool IsOneStopSelected();
        bool IsTwoPlusStopsSelected();

        // Tear down
        void Close();
    }
}
