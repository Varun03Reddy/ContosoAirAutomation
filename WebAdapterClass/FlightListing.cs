
using InterfaceClass;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAdapterClass
{
    /// <summary>
    /// Class for performing flight listing functionalities, including login and searching for available flights.
    /// </summary>
    public class FlightListingPage : IFlightListing
    {
        private IWebDriver driver;

        public FlightListingPage()
        {
            // Initialize WebDriver (e.g., ChromeDriver)
            driver = new ChromeDriver();
        }

        /// <summary>
        /// Performs the login functionality by navigating to the login page and entering credentials.
        /// </summary>
        /// <param name="username">The username to log in.</param>
        /// <param name="password">The password to log in.</param>
        public void Login(string username, string password)
        {
            // Navigate to the application URL
            driver.Navigate().GoToUrl("http://localhost:3000/");
            driver.Manage().Window.Size = new System.Drawing.Size(1296, 688);  // Set window size

            // Click on the "Login" link
            driver.FindElement(By.LinkText("Login")).Click();

            // Input the username and password
            driver.FindElement(By.Id("username")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);

            // Click the login button
            driver.FindElement(By.CssSelector(".btn")).Click();
        }

        /// <summary>
        /// Performs the flight search by selecting the departure and arrival airports, dates, and passengers.
        /// </summary>
        /// <param name="from">The departure airport (e.g., "New York").</param>
        /// <param name="to">The arrival airport (e.g., "Los Angeles").</param>
        /// <param name="departureDate">The departure date of the flight.</param>
        /// <param name="passengers">The number of passengers for the flight.</param>
        /// <param name="returnDate">The return date of the flight (if applicable).</param>
        public void SearchFlights(string from, string to, DateTime departureDate, int passengers, DateTime returnDate)
        {
            // Click on the "Book" button
            driver.FindElement(By.LinkText("Book")).Click();

            // Select Departure Airport
            var fromDropdown = driver.FindElement(By.Id("fromCode"));
            fromDropdown.FindElement(By.XPath($"//option[. = '{from}']")).Click();
            Thread.Sleep(2000);

            // Select Arrival Airport
            var toDropdown = driver.FindElement(By.Id("toCode"));
            toDropdown.FindElement(By.XPath($"//option[. = '{to}']")).Click();
            Thread.Sleep(2000);

            // Select Departure Date (with WebDriverWait)
            driver.FindElement(By.Id("dpa")).Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var departureDateCell = wait.Until(drv =>
                drv.FindElement(By.XPath($"//td[contains(text(), '{departureDate.Day}')]"))
            );
            departureDateCell.Click();

            // Select Passengers
            driver.FindElement(By.Id("passengers")).Click();
            var passengersDropdown = driver.FindElement(By.Id("passengers"));
            passengersDropdown.FindElement(By.XPath($"//option[. = '{passengers}']")).Click();

            // Select Return Date (with WebDriverWait)
            driver.FindElement(By.Id("dpb")).Click();
            var returnDateCell = wait.Until(drv =>
                drv.FindElement(By.XPath($"//td[contains(text(), '{returnDate.Day}')]"))
            );
            returnDateCell.Click();
            //Click on Find Flights button
            driver.FindElement(By.XPath("/html/body/main/section/div/div/div[3]/div/form/fieldset/button")).Click();
        }

        /// <summary>
        /// Lists all available flights after a search is performed.
        /// </summary>
        public List<IWebElement> ListAvailableFlights()
        {
            // Example selector for listing flight results
            var flightListings = driver.FindElements(By.CssSelector(".block-flights-results-list-item")).ToList();

            if (flightListings.Count == 0)
            {
                Console.WriteLine("No flights available.");
            }
            else
            {
                Console.WriteLine("Available Flights:");
                foreach (var flight in flightListings)
                {
                    Console.WriteLine(flight.Text);  // Display flight details
                }
            }

            // Return the list of available flights
            return flightListings;
        }

        /// <summary>
        /// Closes the WebDriver and shuts down the browser session.
        /// </summary>
        public void Close()
        {
            driver.Quit();  // Ensure the browser is closed and resources are released
        }
    }
}