using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Project_A.Controllers
{

    public class PDFFooter : PdfPageEventHelper
    {
        // write on top of document
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            base.OnOpenDocument(writer, document);
            PdfPTable tabFot = new PdfPTable(new float[] { 1F });
            tabFot.SpacingAfter = 10F;
            PdfPCell cell;
            tabFot.TotalWidth = 300F;
            cell = new PdfPCell(new Phrase(""));
            cell.Border = Rectangle.NO_BORDER;
            tabFot.AddCell(cell);
            tabFot.WriteSelectedRows(0, -1, 150, document.Top, writer.DirectContent);
        }

        // write on start of each page
        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);
            PdfPTable tabFot = new PdfPTable(new float[] { 1F });
            PdfPCell cell;
            tabFot.TotalWidth = 300F;
            cell = new PdfPCell(new Phrase("TEST Header"));
            cell.Border = Rectangle.NO_BORDER;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            tabFot.AddCell(cell);
            tabFot.WriteSelectedRows(0, -1, 150, document.Top, writer.DirectContent);

        }

        // write on end of each page
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            DateTime horario = DateTime.Now;
            base.OnEndPage(writer, document);
            PdfPTable tabFot = new PdfPTable(new float[] { 1F });
            PdfPCell cell;
            tabFot.TotalWidth = 300F;
            cell = new PdfPCell(new Phrase("TEST" + " - " + horario));
            cell.Border = Rectangle.NO_BORDER;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            tabFot.AddCell(cell);
            tabFot.WriteSelectedRows(0, -1, 150, document.Bottom, writer.DirectContent);
        }

        //write on close of document
        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);
        }
    }


    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Create()
        {
            ViewBag.Message = "Modifique los valores del la asignación";
            return View();
        }

        public ActionResult Users()
        {
            ViewBag.Message = "Personal autorizado y asignaciones realizadas";

            return View();
        }

        public ActionResult Devices()
        {
            ViewBag.Message = "Estado de activos";

            return View();
        }



        public ActionResult GeneratePDF()
        {
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                Document document = new Document(PageSize.A4, 50, 50, 50, 50);
              
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                
                writer.PageEvent = new PDFFooter();
                document.Open();
               


                string text = @"
El presente documento es aplicable para el personal asignado a cualquiera de las personas morales del Grupo Corporativo conocido comercialmente como “HITSS” y/o a cualquiera de sus clientes, ya sea que se encuentre contratado por alguna de dichas personas morales o por un tercero, y a quien en lo sucesivo se denominará “USUARIO”. 

Por medio de la presente el “USUARIO” reconoce y acepta recibir para el resguardo y operación, el equipo de cómputo que se detalla más adelante (en lo sucesivo el “EQUIPO”, el cual no es de su propiedad y que cuenta con los accesorios y componentes necesarios para su buen funcionamiento). 

TIPO DE EQUIPO:	PORTATIL             ESTADO DEL EQUIPO:	USADO                   MARCA CHASIS: HP
PROCESADOR:	Intel(R) Core(TM) i7-8550U CPU @ 1.80GHz 1.99GHz                    MODELO:	Probook 644 	        	MARCA:	INTEL
N° DE SERIE:	5CG90488NT                  DISCO DURO:	238468.5 MB                          RAM: 8192 GB
		
Otros Accesorios:	Cargador HP    |    Marca monitor: DELL      Modelo: E176FPf      S/N: CN-0CC639-72872-61F-78HT         No.Inv: G-0000000294 Marca monitor2:                              Modelo2:                            S/N: No.Inv:               Observaciones:	N-0000000700            Fortitoken NS:
Dicho “EQUIPO” queda bajo responsabilidad del “USUARIO”, por lo que en caso de encontrar cualquier falla de funcionamiento o avería deberá reportarlo inmediatamente al equipo de Soporte Técnico para su reparación y en su caso reposición. De manera enunciativa, más no limitativa, el “USUARIO” se obliga a:

I.	Cuidar el contenido y seguridad de la información que se encuentre en el “EQUIPO” y en discos de cualquier tipo que contengan respaldo de dicha información.
II.	En caso de robo del equipo, dar aviso inmediato a su supervisor y al área de Soporte Técnico, presentar la Denuncia del Robo ante las autoridades correspondientes, obtener copia certificada del Acta del Ministerio Público y entregarla a su supervisor para el trámite de reembolso con el Seguro.
III.	En caso de pérdida del equipo, dar aviso inmediato a su supervisor y al área de Soporte Técnico, presentar la Denuncia de Hechos ante autoridad competente, obtener copia certificada de la misma y entregarla a su supervisor para solicitar el trámite de reembolso con el Seguro.
IV.	En caso de no presentar la copia certificada del Acta del Ministerio Público o la copia certificada de la Denuncia de Hechos por robo o pérdida del equipo respectivamente, reconocer y aceptar que le sea descontado vía nómina el 100% del valor del equipo depreciado. (La depreciación contable se calcula mensualmente a partir del valor de compra del equipo y considerando una vida útil de 36 meses.)
V.	No realizar reparaciones al hardware por su cuenta ni actualizar o introducir versiones al software que se encuentre en operación en el “EQUIPO” a su cargo, salvo las actualizaciones autorizadas por Soporte Técnico al sistema operativo; ni instalar programas que no sean necesarios para el cumplimiento de sus actividades; ni realizar cualquier otra reparación o modificación en el hardware o software; así como no debe extraer o modificar cualquier componente o accesorio del “EQUIPO” o software, por lo que en caso de encontrarse alguna anomalía imputable al “USUARIO”, éste se hará acreedor a las sanciones que correspondan.
VI.	Si el equipo presenta daños por mal uso, golpes, derramamiento de líquidos y aquellas causas no relacionadas a un uso normal, notificar a su supervisor y al área de Soporte Técnico para que se envíe el “EQUIPO” a un centro de servicio autorizado del fabricante para su diagnóstico y reparación  de los dispositivos afectados por el daño, en el entendido de  que el costo de dicha reparación correrá por exclusiva cuenta del “USUARIO”.

Por todo lo anteriormente señalado, el área de Soporte Técnico podrá realizar auditorías de inspección del “EQUIPO” en cualquier tiempo, para cerciorarse del cumplimiento de las obligaciones establecidas en la presente carta y las políticas de seguridad de la información.

En caso de que el “USUARIO” infrinja algún punto de los anteriormente mencionados, el área de Soporte Técnico lo reportará a la Dirección Corporativa de  Finanzas y Administración y a la Dirección a la que esté adscrito el ”USUARIO”.

FIRMA DE  CONFORMIDAD DEL “USUARIO”

Por medio de la presente reconozco, acepto y me obligo a cumplir con los lineamientos establecidos en esta “Carta Responsiva”.

RECIBO Y ACEPTO";


                string text2 = @"Políticas de Seguridad de la Información

Con el fin de poder garantizar la confidencialidad de la información, su divulgación no autorizada, el acceso a la información no permitida, la integridad que asegura que la información se encuentre protegida de la destrucción o pérdida y la disponibilidad de la información: 

•	El usuario no deberá almacenar, enviar, recibir o mostrar información obscena u ofensiva, aunque sea de manera temporal, en áreas donde puedan ser vistas por uno o más individuos de manera pasiva o inadvertida.
•	El usuario no deberá de llevar a cabo cualquier actividad que pueda afectar de manera directa o indirecta la imagen de la organización o las relaciones que tenga con sus clientes.
•	La información contenida dentro del equipo del usuario queda a responsabilidad completa del usuario, la cual debe ser respaldada periódicamente por el mismo para evitar su pérdida en caso de desastre.
•	El usuario no deberá realizar un uso indebido del correo para transmitir material como correos en masa (spamming), cadenas de mensajes o anuncios para usos privados o personales.
•	Se prohíbe el acceso a la red del patrón a cualquier equipo que no cuente con las políticas regulatorias para equipos.
•	El usuario no deberá intentar ganar acceso a servidores o cuentas de otras personas sin tener el permiso correspondiente y tratar de quebrantar cualquier tipo de seguridad (HW, SW, etc.)
•	El usuario no deberá intentar modificar los sistemas operativos, configuraciones de equipo de cómputo (wallpapers, desktops, temas de escritorio, etc.) sin tener la autorización por escrito del área de Soporte Técnico.
•	Queda prohíbo realizar prueba de estrés que tengan un impacto directo sobre la red del patrón, en caso de que sean necesarias, se deberá tener una carta por escrito con los datos del impacto, duración y responsable del área de Soporte Técnico.
•	Está prohibido que todo Software que no tenga su correspondiente licencia válida, sea instalado en equipos de cómputo sin la autorización previa de Soporte Técnico.
•	Están prohibidos los accesos no autorizados, alterar información, destruir información, programas, código fuente o correos electrónicos.
•	El usuario no deberá intentar accesos no autorizados sea en la red local, redes remotas, computadoras personales, laptops, aunque éstos tengan permisos abiertos, sin la autorización previa y por escrito del área de Soporte Técnico.
•	El usuario no deberá intentar afectar la disponibilidad o calidad de los servicios de red de voz y/o datos del patrón ya sea de manera intencional o no, debido a actividades las cuales no hubieran sido validadas previamente con el área de Soporte Técnico.
•	Está prohibido que todo tipo de música o formatos de video sean almacenados en equipo que pertenezcan al patrón, ya sean computadoras, laptops o servidores.
•	Está prohibido el acceso a sitios con contenidos que realicen streaming o transmisión de audio o video a no ser que sean antes validados previamente y por escrito con el área de Soporte Técnico. 
•	Está prohibido el acceso a instalaciones especializadas como SITEs, ésta obligación aplica totalmente tanto al personal del patrón, como al personal externo (visitas de clientes, proveedores, estudiantes, etc.). Solo podrá entrar el personal de Soporte técnico con clave debidamente validada.
•	No se permite ningún medio de colaboración aparte del Xlite y Spark, el cual no haya sido previamente validado por el área de Soporte Técnico por escrito
•	Queda prohibido usar juegos de cualquier índole, sea por Internet o instalados en los equipos.
•	Queda prohibido usar túneles, vpn o proxy para conseguir acceso a sitios bloqueados.
•	Los equipos personales laptop de los usuarios no podrán conectarse a la infraestructura del patrón, debe solicitarlo un gerente ó dirección y ésta deberá cumplir con los lineamientos de la política de seguridad sin excepción alguna. 
•	No se pueden conectar equipos de telecomunicaciones que den acceso a otras redes que no pertenezcan a la red del patrón, switch, módems, routers ó cualquier otro elemento de comunicación a no ser de que sea aislada la red y no tenga ningún tipo de acceso a la red del patrón.
•	Todo proyecto deberá proveer una partida para el licenciamiento de software para el desarrollo del mismo. 
•	Está prohibida la instalación de equipos de telecomunicaciones que den acceso inalámbrico a la red del patrón si no fue permitido previamente por escrito por el área de Soporte Técnico.
•	Está prohibido dar de alta servidores que tengan acceso a la red del patrón o que se encuentren en las instalaciones del mismo, si no fue permitido previamente por escrito por el área de Soporte Técnico.
•	Está prohibido dar de alta servidores o equipos de telecomunicaciones con servicios de WINS, DNS o DHCP dentro de la red del patrón.
•	Queda prohibido hacer uso de INTERNET para fines personales, el uso de este es una herramienta de trabajo por lo que debe utilizarse única y exclusivamente para el desempeño de sus actividades.
 
RECIBO Y ACEPTO DE CONFORMIDAD";

                                                 string firma= @"____________________________
VILLA AYALA ADAN";

                Paragraph pfirm = new Paragraph();
                pfirm.Alignment = Element.ALIGN_CENTER;
                pfirm.Font = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 7f, BaseColor.BLACK);
                pfirm.Add(firma);

                Paragraph paragraph = new Paragraph();
                paragraph.SpacingBefore = 30;
                paragraph.SpacingAfter = 30;
                paragraph.Alignment = Element.ALIGN_JUSTIFIED;
                paragraph.Font = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 7f, BaseColor.BLACK);
                paragraph.Add(text);
                document.Add(paragraph);
                document.Add(pfirm);
                document.NewPage();

                Paragraph paragraph2 = new Paragraph();
                paragraph2.SpacingBefore = 30;
                paragraph2.SpacingAfter = 30;
                paragraph2.Alignment = Element.ALIGN_JUSTIFIED;
                paragraph2.Font = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 7f, BaseColor.BLACK);
                paragraph2.Add(text2);
                document.Add(paragraph2);
                document.Add(pfirm);
                
                

                document.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
                Response.Clear();
                Response.ContentType = "application/pdf";

                string pdfName = "Prueba";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + pdfName + ".pdf");
                Response.ContentType = "application/pdf";
                Response.Buffer = true;
                Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.End();
                Response.Close();
            }
            return View();
        }
    }

}