using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class Culture13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string[] columns = new string[] { "Id", "IsDeleted", "IsSystemObject", "IsChanged", "SystemIdentificator", "Value", "Name", "IsDefault", "Priority", "IsActive", "IsEnvironmentCulture" };

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
            //   migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "za", "Zhuang, Chuang", "Saɯ cueŋƅ, Saw cuengh", false });*/
        }

        protected override void Down(MigrationBuilder migrationBuilder) { }
    }
}
