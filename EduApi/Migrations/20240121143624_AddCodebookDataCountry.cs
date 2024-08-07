﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddCodebookDataCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                "Cb_Country",
                new string[] { "Id", "IsDeleted", "IsSystemObject", "IsChanged", "SystemIdentificator", "Name", "Value", "IsDefault", "Priority" },
                new object[] { Guid.NewGuid(), false, true, true, "CZ", "Česká republika", "CZ", true, 1 }
            );
            Dictionary<string, string> countries = new Dictionary<string, string>
            {
                { "AF", "Afghanistan" },
                { "AX", " Åland Islands" },
                { "AL", "  Albania" },
                { "DZ", "  Algeria" },
                { "AS", "  American Samoa" },
                { "VI", " Virgin Islands(U.S.)" },
                { "AD", " Andorra" },
                { "AO", " Angola" },
                { "AI", " Anguilla" },
                { "AQ ", "Antarctica" },
                { "AG ", "Antigua and Barbuda" },
                { "AR ", "Argentina" },
                { "AM ", "Armenia" },
                { "AW ", "Aruba" },
                { "AU ", "Australia" },
                { "AZ ", "Azerbaijan" },
                { "BS ", "Bahamas(the)" },
                { "BH ", "Bahrain" },
                { "BD ", "Bangladesh" },
                { "BB ", "Barbados" },
                { "BE ", "Belgium" },
                { "BZ ", "Belize" },
                { "BY ", "Belarus" },
                { "BJ ", "Benin" },
                { "BM ", "Bermuda!" },
                { "BT ", "Bhutan" },
                { "BO", " Bolivia(Plurinational State of)" },
                { "BQ ", "Bonaire, Sint Eustatius and Saba" },
                { "BA  ", "Bosnia and Herzegovina" },
                { "BW  ", "Botswana" },
                { "BV  ", "Bouvet Island" },
                { "BR ", "Brazil" },
                { "IO", " British Indian Ocean Territory(the)" },
                { "VG", " Virgin Islands(British)" },
                { "BN", " Brunei Darussalam" },
                { "BG", "  Bulgaria" },
                { "BF", "  Burkina Faso" },
                { "BI", " Burundi" },
                { "CK", " Cook Islands(the)" },
                { "CW", " Curaçao" },
                { "TD", " Chad" },
                { "ME", " Montenegro" },
                { "CN", " China" },
                { "DK", " Denmark" },
                { "CD", " Congo(the Democratic Republic of the)" },
                { "DM", " Dominica" },
                { "DO", " Dominican Republic(the)" },
                { "DJ", " Djibouti" },
                { "EG", " Egypt" },
                { "EC", " Ecuador" },
                { "ER", " Eritrea" },
                { "EE", " Estonia" },
                { "ET", " Ethiopia" },
                { "FO", " Faroe Islands(the)" },
                { "FK", " Falkland Islands(the)(Malvinas)" },
                { "FJ", " Fiji" },
                { "PH", " Philippines(the)" },
                { "FI", " Finland" },
                { "FR", " France" },
                { "GF", " French Guiana" },
                { "TF", "  French Southern Territories(the)" },
                { "PF", " French Polynesia" },
                { "GA", "  Gabon" },
                { "GM", "  Gambia(the)" },
                { "GH", " Ghana" },
                { "GI", " Gibraltar" },
                { "GD", " Grenada" },
                { "GL", " Greenland" },
                { "GE", " Georgia" },
                { "GP", " Guadeloupe" },
                { "GU", " Guam" },
                { "GT", " Guatemala" },
                { "GG", " Guernsey" },
                { "GN", " Guinea" },
                { "GW", " Guinea-Bissau" },
                { "GY", " Guyana" },
                { "HT", " Haiti" },
                { "HM", " Heard Island and McDonald Islands" },
                { "HN", " Honduras" },
                { "HK", " Hong Kong" },
                { "CL", "  Chile" },
                { "HR", "  Croatia" },
                { "IN", "  India" },
                { "ID", "  Indonesia" },
                { "IQ", "  Iraq" },
                { "IR", "  Iran(Islamic Republic of)" },
                { "IE", " Ireland" },
                { "IS", " Iceland" },
                { "IT", " Italy" },
                { "IL", " Israel" },
                { "JM", " Jamaica" },
                { "JP", " Japan" },
                { "YE", " Yemen" },
                { "JE", " Jersey" },
                { "ZA", " South Africa" },
                { "GS", "  South Georgia and the South Sandwich Islands" },
                { "SS", "  South Sudan" },
                { "JO", " Jordan" },
                { "KY", " Cayman Islands(the)" },
                { "KH", " Cambodia" },
                { "CM", " Cameroon" },
                { "CA", " Canada" },
                { "CV", " Cape Verde" },
                { "QA", "  Qatar" },
                { "KZ", "  Kazakhstan" },
                { "KE", "  Kenya" },
                { "KI", "  Kiribati" },
                { "CC", "  Cocos(Keeling) Islands(the)" },
                { "CO", " Colombia" },
                { "KM", " Comoros(the)" },
                { "CG", " Congo(the)" },
                { "KP", " Korea(the Democratic People's Republic of)" },
                { "KR", " Korea(the Republic of)" },
                { "XK", " Kosovo" },
                { "CR", "  Costa Rica" },
                { "CU", " Cuba" },
                { "KW", " Kuwait" },
                { "CY", " Cyprus" },
                { "KG ", "Kyrgyzstan" },
                { "LA", " Lao People's Democratic Republic (the)" },
                { "LS", " Lesotho" },
                { "LB", " Lebanon" },
                { "LR", " Liberia" },
                { "LY", " Libya" },
                { "LI", " Liechtenstein" },
                { "LT", " Lithuania" },
                { "LV", " Latvia" },
                { "LU", " Luxembourg" },
                { "MO", " Macao" },
                { "MG", " Madagascar" },
                { "HU", " Hungary" },
                { "MK", " North Macedonia" },
                { "MY", "  Malaysia" },
                { "MW ", " Malawi" },
                { "MV", "  Maldives" },
                { "ML", "  Mali" },
                { "MT", "  Malta" },
                { "IM ", " Isle of Man" },
                { "MA ", " Morocco" },
                { "MH ", " Marshall Islands(the)" },
                { "MQ ", "Martinique" },
                { "MU", " Mauritius" },
                { "MR", " Mauritania" },
                { "YT", " Mayotte" },
                { "UM", " United States Minor Outlying Islands(the)" },
                { "MX", " Mexico" },
                { "FM", " Micronesia(Federated States of)" },
                { "MD ", "Moldova(the Republic of)" },
                { "MC", " Monaco" },
                { "MN", " Mongolia" },
                { "MS", " Montserrat" },
                { "MZ", " Mozambique" },
                { "MM", " Myanmar" },
                { "NA", " Namibia" },
                { "NR", " Nauru" },
                { "DE", " Germany" },
                { "NP", " Nepal" },
                { "NE", " Niger(the)" },
                { "NG", " Nigeria" },
                { "NI", " Nicaragua" },
                { "NU", " Niue" },
                { "NL", " Netherlands(the)" },
                { "NF", " Norfolk Island" },
                { "NO ", " Norway" },
                { "NC", "  New Caledonia" },
                { "NZ", " New Zealand" },
                { "OM ", " Oman" },
                { "PK ", " Pakistan" },
                { "PW ", " Palau" },
                { "PS ", " Palestine, State of" },
                { "PA", " Panama" },
                { "PG", " Papua New Guinea" },
                { "PY", " Paraguay" },
                { "PE", " Peru" },
                { "PN", " Pitcairn" },
                { "CI", " Côte d'Ivoire" },
                { "PL", "Poland" },
                { "PR", " Puerto Rico" },
                { "PT ", " Portugal" },
                { "AT ", " Austria" },
                { "RE ", " Réunion" },
                { "GQ ", " Equatorial Guinea" },
                { "RO ", "Romania" },
                { "RU ", "Russian Federation(the)" },
                { "RW ", "Rwanda" },
                { "GR", " Greece" },
                { "PM ", "Saint Pierre and Miquelon" },
                { "SV ", " El Salvador" },
                { "WS ", "Samoa" },
                { "SM ", "San Marino" },
                { "SA ", " Saudi Arabia" },
                { "SN", " Senegal" },
                { "MP", " Northern Mariana Islands(the)" },
                { "SC", " Seychelles" },
                { "SL", " Sierra Leone" },
                { "SG", "  Singapore" },
                { "SI", "  Slovenia" },
                { "SO ", " Somalia" },
                { "AE ", " United Arab Emirates(the)" },
                { "US ", "United States of America(the)" },
                { "RS ", "Serbia" },
                { "CF ", "Central African Republic(the)" },
                { "SD", " Sudan(the)" },
                { "SR", " Suriname" },
                { "SH ", "Saint Helena, Ascension and Tristan da Cunha" },
                { "LC ", " Saint Lucia" },
                { "BL", " Saint Barthélemy" },
                { "KN", "  Saint Kitts and Nevis" },
                { "MF", " Saint Martin(French part)" },
                { "SX ", "Sint Maarten(Dutch part)" },
                { "ST ", "Sao Tome and Principe" },
                { "VC ", " Saint Vincent and the Grenadines" },
                { "SZ  ", "Eswatini" },
                { "SY ", "Syrian Arab Republic" },
                { "SB  ", "Solomon Islands" },
                { "ES ", "Spain" },
                { "SJ ", "Svalbard and Jan Mayen" },
                { "LK ", " Sri Lanka" },
                { "SE ", "Sweden" },
                { "CH ", "Switzerland" },
                { "TJ ", "Tajikistan" },
                { "TZ ", "Tanzania, United Republic of" },
                { "TH ", "Thailand" },
                { "TW ", "Taiwan(Province of China)" },
                { "TG ", "Togo" },
                { "TK ", "Tokelau" },
                { "TO ", "Tonga" },
                { "TT ", "Trinidad and Tobago" },
                { "TN ", "Tunisia" },
                { "TR ", "Turkey" },
                { "TM", " Turkmenistan" },
                { "TC", " Turks and Caicos Islands(the)" },
                { "TV ", "Tuvalu" },
                { "UG ", "Uganda" },
                { "UA ", "Ukraine" },
                { "UY ", "Uruguay" },
                { "UZ ", "Uzbekistan" },
                { "CX ", "Christmas Island" },
                { "VU", "  Vanuatu" },
                { "VA", "  Holy See(the)" },
                { "GB ", "United Kingdom of Great Britain and Northern Ireland(the)" },
                { "VE", " Venezuela(Bolivarian Republic of)" },
                { "VN", " Viet Nam" },
                { "TL", "  Timor - Leste" },
                { "WF", " Wallis and Futuna" },
                { "ZM", " Zambia" },
                { "EH", " Western Sahara" },
                { "ZW", "  Zimbabwe" }
            };
            int priority = 100;
            foreach (KeyValuePair<string, string> item in countries)
            {
                migrationBuilder.InsertData(
                    "Cb_Country",
                    new string[]
                    {
                        "Id",
                        "IsDeleted",
                        "IsSystemObject",
                        "IsChanged",
                        "SystemIdentificator",
                        "Name",
                        "Value",
                        "IsDefault",
                        "Priority"
                    },
                    new object[] { Guid.NewGuid(), false, true, true, item.Key.Trim(), item.Value.Trim(), item.Key.Trim(), false, priority }
                );
                priority = priority + 1;
            }
            string[] columns = new string[]
            {
                "Id",
                "IsDeleted",
                "IsSystemObject",
                "IsChanged",
                "SystemIdentificator",
                "Name",
                "Value",
                "IsDefault",
                "Priority"
            };
            object[] value = new object[] { Guid.NewGuid(), false, true, true, "SK", "Slovenská republika", "SK", false, 2 };
            migrationBuilder.InsertData("Cb_Country", columns, value);

            string[] column = new string[]
            {
                "Id",
                "IsDeleted",
                "IsSystemObject",
                "IsChanged",
                "SystemIdentificator",
                "Subject",
                "EmailBodyHtml",
                "EmailBodyPlainText",
                "IsHtml",
                "From",
                "IsDefault",
                "Priority"
            };
            object[] valueEmail = new object[]
            {
                Guid.NewGuid(),
                false,
                true,
                true,
                "REGISTRATION_USER_cs-CZ",
                "Potvrzení registrace",
                "Děkujeme Vám za registraci",
                "Děkujeme Vám za registraci",
                true,
                "info@myedu.com",
                false,
                0
            };
            migrationBuilder.InsertData("Cb_Email", column, valueEmail);

            string[] columnsLicence = new string[]
            {
                "Id",
                "IsDeleted",
                "IsSystemObject",
                "IsChanged",
                "SystemIdentificator",
                "Name",
                "Value",
                "IsDefault",
                "MaximumUser",
                "MaximumBranch",
                "MaximumCourse",
                "MounthPrice",
                "OneYearSale",
                "SendCourseInquiry",
                "CreatePrivateCourse",
                "Priority"
            };
            object[] data = new object[]
            {
                Guid.NewGuid(),
                false,
                true,
                true,
                "FREE",
                "FREE_LICENSE",
                "FREE_LICENSE",
                true,
                10,
                10,
                10,
                false,
                false,
                false,
                false,
                3
            };
            migrationBuilder.InsertData("Cb_License", columnsLicence, data);

            List<string> couserStatus = new List<string> { "ONLINE", "ATTENDANCE", "COMBINED" };
            string[] columnCType = new string[]
            {
                "Id",
                "IsDeleted",
                "IsSystemObject",
                "IsChanged",
                "SystemIdentificator",
                "Name",
                "Value",
                "IsDefault",
                "Priority"
            };
            int priorityCType = 1;
            foreach (string item in couserStatus)
            {
                object[] valueCtype = new object[] { Guid.NewGuid(), false, true, true, item, item, item, false, priorityCType };
                migrationBuilder.InsertData("Cb_CourseType", columnCType, valueCtype);
                priorityCType++;
            }

            List<string> couserStatusType = new List<string> { "NEW", "IN_PREPARATION", "OPEN", "ONGOING", "CLOSED" };
            string[] columnCsType = new string[]
            {
                "Id",
                "IsDeleted",
                "IsSystemObject",
                "IsChanged",
                "SystemIdentificator",
                "Name",
                "Value",
                "IsDefault",
                "Priority"
            };
            int priorityCsType = 1;
            foreach (string item in couserStatusType)
            {
                object[] valueCsType = new object[] { Guid.NewGuid(), false, true, true, item, item, item, false, priorityCsType };
                migrationBuilder.InsertData("Cb_CourseStatus", columnCsType, valueCsType);
                priorityCsType++;
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder) { }
    }
}
