using DinkToPdf;
using DinkToPdf.Contracts;
using System.Text;
using UserNotebook.Core.Models;

namespace UserNotebook.Core.Services
{
    public class ReportService : IReportService
    {
        private readonly IConverter _converter;

        public ReportService(IConverter converter)
        {
            _converter = converter;
        }

        public byte[] GenerateUserReport(List<UserDto> users)
        {
            var htmlContent = BuildHtmlContent(users);
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Landscape,
                PaperSize = PaperKind.A4,
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = htmlContent,
                WebSettings = { DefaultEncoding = "utf-8" },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
            };
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            var pdf = _converter.Convert(doc);
            return pdf;
        }

        private string BuildHtmlContent(List<UserDto> users)
        {
            var sb = new StringBuilder();
            sb.Append(@"
<!DOCTYPE html>
<html lang='pl'>
<head>
    <link rel=""stylesheet"" href=""https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"">
</head>
<body>
    <div class='container'>
        <h1 class='text-center mb-4'>Raport Użytkowników</h1>
        <table class='table table-bordered table-sm'>
            <thead class='table-dark'>
                <tr>
                    <th>Tytuł</th>
                    <th>Imię</th>
                    <th>Nazwisko</th>
                    <th>Data urodzenia</th>
                    <th>Płeć</th>
                    <th>Wiek</th>
                    <th>Dodatkowe Parametry</th>
                </tr>
            </thead>
            <tbody>");

            foreach (var user in users)
            {
                var title = user.Plec == "Mężczyzna" ? "Pan" : "Pani";
                var age = DateTime.Now.Year - user.DataUrodzenia.Year;
                var additionalParameters = string.Join(", ", user.DodatkoweParametry.Select(p => $"{p.Key}: {p.Value}"));

                sb.AppendFormat(@"
                <tr>
                    <td>{0}</td>
                    <td>{1}</td>
                    <td>{2}</td>
                    <td>{3:yyyy-MM-dd}</td>
                    <td>{4}</td>
                    <td>{5}</td>
                    <td>{6}</td>
                </tr>", title, user.Imie, user.Nazwisko, user.DataUrodzenia, user.Plec, age, additionalParameters);
            }

            sb.Append(@"
            </tbody>
        </table>
    </div>
</body>
</html>");

            return sb.ToString();
        }
    }
}
