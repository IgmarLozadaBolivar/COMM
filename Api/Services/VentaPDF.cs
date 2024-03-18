using QuestPDF.Fluent;
using QuestPDF.Previewer;

namespace Api.Services;

public class VentaPDF
{
    public VentaPDF()
    {
        QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
        var document = Document.Create(contenedor =>
        {
            // Aquí puedes definir el contenido de tu documento PDF
        });

        document.ShowInPreviewer();

        document.ShowInPreviewer(12500);
    }
}