using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class Culture7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string[] columns = new string[] { "Id", "IsDeleted", "IsSystemObject", "IsChanged", "SystemIdentificator", "Value", "Name", "IsDefault", "Priority", "IsActive", "IsEnvironmentCulture" };

            migrationBuilder.InsertData(
                "Cb_Culture",
                columns,
                new object[] { Guid.NewGuid(), false, true, true, "ff", "Fula; Fulah; Pulaar; Pular", "Fulfulde, Pulaar, Pular", false, 100, true, false }
            );
            /*migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "gl", "Galician", "Galego", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "ka", "Georgian", "ქართული", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "de", "German", "Deutsch", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "el", "Greek, Modern", "Ελληνικά", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "gn", "Guaraní", "Avañeẽ", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "gu", "Gujarati", "ગુજરાતી", false, 100, true });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "ht", "Haitian; Haitian Creole", "Kreyòl ayisyen", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "ha", "Hausa", "Hausa, هَوُسَ", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "he", "Hebrew (modern)", "עברית", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "hz", "Herero", "Otjiherero", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "hi", "Hindi", "हिन्दी, हिंदी", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "ho", "Hiri Motu", "Hiri Motu", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "hu", "Hungarian", "Magyar", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "ia", "Interlingua", "Interlingua", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "id", "Indonesian", "Bahasa Indonesia", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "ie", "Interlingue", "Originally called Occidental; then Interlingue after WWII", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "ga", "Irish", "Gaeilge", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "ig", "Igbo", "Asụsụ Igbo", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "ik", "Inupiaq", "Iñupiaq, Iñupiatun", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "io", "Ido", "Ido", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "is", "Icelandic", "Íslenska", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "it", "Italian", "Italiano", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "iu", "Inuktitut", "ᐃᓄᒃᑎᑐᑦ", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "ja", "Japanese", "日本語 (にほんご／にっぽんご)", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "jv", "Javanese", "basa Jawa", false, 100, true, false });
            //migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "kl", "Kalaallisut, Greenlandic", "kalaallisut, kalaallit oqaasii", false, 100, true, false });
            /*migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "kn", "Kannada", "ಕನ್ನಡ", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "kr", "Kanuri", "Kanuri", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "ks", "Kashmiri", "कश्मीरी, كشميري‎", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "kk", "Kazakh", "Қазақ тілі", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "km", "Khmer", "ភាសាខ្មែរ", false, 100, true, false });
            /*migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "ki", "Kikuyu, Gikuyu", "Gĩkũyũ", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "rw", "Kinyarwanda", "Ikinyarwanda", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "ky", "Kirghiz, Kyrgyz", "кыргыз тили", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "kv", "Komi", "коми кыв", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "kg", "Kongo", "KiKongo", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "ko", "Korean", "한국어 (韓國語), 조선말 (朝鮮語)", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "ku", "Kurdish", "Kurdî, كوردی‎", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "kj", "Kwanyama, Kuanyama", "Kuanyama", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "la", "Latin", "latine, lingua latina", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "lb", "Luxembourgish, Letzeburgesch", "Lëtzebuergesch", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "lg", "Luganda", "Luganda", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "li", "Limburgish, Limburgan, Limburger", "Limburgs", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "ln", "Lingala", "Lingála", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "lo", "Lao", "ພາສາລາວ", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "lt", "Lithuanian", "lietuvių kalba", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "lu", "Luba-Katanga", "", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "lv", "Latvian", "latviešu valoda", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "gv", "Manx", "Gaelg, Gailck", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "mk", "Macedonian", "македонски јазик", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "mg", "Malagasy", "Malagasy fiteny", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "ms", "Malay", "bahasa Melayu, بهاس ملايو‎", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "ml", "Malayalam", "മലയാളം", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "mt", "Maltese", "Malti", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "mi", "Māori", "te reo Māori", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "mr", "Marathi (Marāṭhī)", "मराठी", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "mh", "Marshallese", "Kajin M̧ajeļ", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "mn", "Mongolian", "монгол", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "na", "Nauru", "Ekakairũ Naoero", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "nv", "Navajo, Navaho", "Diné bizaad, Dinékʼehǰí", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "nb", "Norwegian Bokmål", "Norsk bokmål", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "nd", "North Ndebele", "isiNdebele", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "ne", "Nepali", "नेपाली", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "ng", "Ndonga", "Owambo", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "nn", "Norwegian Nynorsk", "Norsk nynorsk", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "no", "Norwegian", "Norsk", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "ii", "Nuosu", "ꆈꌠ꒿ Nuosuhxop", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "nr", "South Ndebele", "isiNdebele", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "oc", "Occitan", "Occitan", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "oj", "Ojibwe, Ojibwa", "ᐊᓂᔑᓈᐯᒧᐎᓐ", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "cu", "Old Church Slavonic, Church Slavic, Church Slavonic, Old Bulgarian, Old Slavonic", "ѩзыкъ словѣньскъ", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "om", "Oromo", "Afaan Oromoo", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "or", "Oriya", "ଓଡ଼ିଆ", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "os", "Ossetian, Ossetic", "ирон æвзаг", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "pa", "Panjabi, Punjabi", "ਪੰਜਾਬੀ, پنجابی‎", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "pi", "Pāli", "पाऴि", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "fa", "Persian", "فارسی", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "pl", "Polish", "polski", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "ps", "Pashto, Pushto", "پښتو", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "pt", "Portuguese", "Português", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "qu", "Quechua", "Runa Simi, Kichwa", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "rm", "Romansh", "rumantsch grischun", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "rn", "Kirundi", "kiRundi", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "ro", "Romanian, Moldavian, Moldovan", "română", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "ru", "Russian", "русский язык", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "sa", "Sanskrit (Saṁskṛta)", "संस्कृतम्", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "sc", "Sardinian", "sardu", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "sd", "Sindhi", "सिन्धी, سنڌي، سندھی‎", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "se", "Northern Sami", "Davvisámegiella", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "sm", "Samoan", "gagana faa Samoa", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "sg", "Sango", "yângâ tî sängö", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "sr", "Serbian", "српски језик", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "gd", "Scottish Gaelic; Gaelic", "Gàidhlig", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "sn", "Shona", "chiShona", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "si", "Sinhala, Sinhalese", "සිංහල", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "sk", "Slovak", "slovenčina", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "sl", "Slovene", "slovenščina", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "so", "Somali", "Soomaaliga, af Soomaali", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "st", "Southern Sotho", "Sesotho", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "es", "Spanish; Castilian", "español, castellano", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "su", "Sundanese", "Basa Sunda", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "sw", "Swahili", "Kiswahili", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "ss", "Swati", "SiSwati", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "sv", "Swedish", "svenska", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "ta", "Tamil", "தமிழ்", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "te", "Telugu", "తెలుగు", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "tg", "Tajik", "тоҷикӣ, toğikī, تاجیکی‎", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "th", "Thai", "ไทย", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "ti", "Tigrinya", "ትግርኛ", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "bo", "Tibetan Standard, Tibetan, Central", "བོད་ཡིག", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "tk", "Turkmen", "Türkmen, Түркмен", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "tl", "Tagalog", "Wikang Tagalog, ᜏᜒᜃᜅ᜔ ᜆᜄᜎᜓᜄ᜔", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "tn", "Tswana", "Setswana", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "to", "Tonga (Tonga Islands)", "faka Tonga", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "tr", "Turkish", "Türkçe", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "ts", "Tsonga", "Xitsonga", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "tt", "Tatar", "татарча, tatarça, تاتارچا‎", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "tw", "Twi", "Twi", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "ty", "Tahitian", "Reo Tahiti", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "ug", "Uighur, Uyghur", "Uyƣurqə, ئۇيغۇرچە‎", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "uk", "Ukrainian", "українська", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "ur", "Urdu", "اردو", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "uz", "Uzbek", "zbek, Ўзбек, أۇزبېك‎", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "ve", "Venda", "Tshivenḓa", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "vi", "Vietnamese", "Tiếng Việt", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "vo", "Volapük", "Volapük", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "wa", "Walloon", "Walon", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "cy", "Welsh", "Cymraeg", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "wo", "Wolof", "Wollof", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "fy", "Western Frisian", "Frysk", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "xh", "Xhosa", "isiXhosa", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "yi", "Yiddish", "ייִדיש", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "yo", "Yoruba", "Yorùbá", false, 100, true, false });
            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "za", "Zhuang, Chuang", "Saɯ cueŋƅ, Saw cuengh", false*/
        }

        protected override void Down(MigrationBuilder migrationBuilder) { }
    }
}
