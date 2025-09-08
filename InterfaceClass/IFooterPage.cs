/*
 * Copyright (c) 2025 Varun Reddy
 * All rights reserved.
 *
 * This source code is licensed under the terms specified by the owner.
 */
using System;

namespace InterfaceClass
{
    /// <summary>
    /// Defines contract for interacting with the footer section of the website.
    /// Each method corresponds to a footer link navigation.
    /// </summary>
    public interface IFooter
    {
        // ABOUT CONTOSO
        void ClickWhoWeAre();
        void ClickContactUs();
        void ClickTravelAdvisories();
        void ClickCustomerCommitment();
        void ClickFeedback();
        void ClickPrivacyNotice();

        // CUSTOMER SERVICE
        void ClickCareers();
        void ClickLegal();
        void ClickNewsroom();
        void ClickInvestorRelations();
        void ClickContractOfCarriage();
        void ClickTarmacDelayPlan();
        void ClickSiteMap();

        // PRODUCTS AND SERVICES
        void ClickOptionalServicesAndFees();
        void ClickCorporateTravel();
        void ClickTravelAgents();
        void ClickCargo();
        void ClickGiftCertificates();
        void ClickFollowUs();
    }
}
