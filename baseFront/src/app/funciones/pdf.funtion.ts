import jsPDF from "jspdf";

export function generate_pdf_to_html(html: string) {
    var doc = new jsPDF({
        orientation: 'landscape',
    });
    doc.setFont("courier");
    doc.setFontSize(24);
    doc.html(html);

}