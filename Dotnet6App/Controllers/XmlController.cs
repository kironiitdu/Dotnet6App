using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Xml.Serialization;

namespace Dotnet6App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XmlController : ControllerBase
    {
        [HttpPost]
        [Produces("application/xml")]
        [Consumes("application/xml")]
        public async Task<ActionResult> PostAsync()
        {
            string xml;
            using (System.IO.StreamReader reader = new System.IO.StreamReader(Request.Body, Encoding.UTF8))
            {
                xml = await reader.ReadToEndAsync();
            }
            XmlSerializer serializer = new XmlSerializer(typeof(Envelope));
            using (TextReader reader = new StringReader(xml))
            {
                Envelope result = (Envelope)serializer.Deserialize(reader);
                return Ok(result);

            }


        }
    }

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.xmlsoap.org/soap/envelope/", IsNullable = false)]
    public partial class Envelope
    {

        private object headerField;

        private EnvelopeBody bodyField;

        /// <remarks/>
        public object Header
        {
            get
            {
                return this.headerField;
            }
            set
            {
                this.headerField = value;
            }
        }

        /// <remarks/>
        public EnvelopeBody Body
        {
            get
            {
                return this.bodyField;
            }
            set
            {
                this.bodyField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public partial class EnvelopeBody
    {

        private PaymentNotificationRequest paymentNotificationRequestField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
        public PaymentNotificationRequest PaymentNotificationRequest
        {
            get
            {
                return this.paymentNotificationRequestField;
            }
            set
            {
                this.paymentNotificationRequestField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class PaymentNotificationRequest
    {

        private string userField;

        private string passwordField;

        private string hashValField;

        private ushort transTypeField;

        private string transIDField;

        private uint transTimeField;

        private decimal transAmountField;

        private ulong accountNrField;

        private string narrativeField;

        private uint phoneNrField;

        private string customerNameField;

        private string statusField;

        /// <remarks/>
        public string User
        {
            get
            {
                return this.userField;
            }
            set
            {
                this.userField = value;
            }
        }

        /// <remarks/>
        public string Password
        {
            get
            {
                return this.passwordField;
            }
            set
            {
                this.passwordField = value;
            }
        }

        /// <remarks/>
        public string HashVal
        {
            get
            {
                return this.hashValField;
            }
            set
            {
                this.hashValField = value;
            }
        }

        /// <remarks/>
        public ushort TransType
        {
            get
            {
                return this.transTypeField;
            }
            set
            {
                this.transTypeField = value;
            }
        }

        /// <remarks/>
        public string TransID
        {
            get
            {
                return this.transIDField;
            }
            set
            {
                this.transIDField = value;
            }
        }

        /// <remarks/>
        public uint TransTime
        {
            get
            {
                return this.transTimeField;
            }
            set
            {
                this.transTimeField = value;
            }
        }

        /// <remarks/>
        public decimal TransAmount
        {
            get
            {
                return this.transAmountField;
            }
            set
            {
                this.transAmountField = value;
            }
        }

        /// <remarks/>
        public ulong AccountNr
        {
            get
            {
                return this.accountNrField;
            }
            set
            {
                this.accountNrField = value;
            }
        }

        /// <remarks/>
        public string Narrative
        {
            get
            {
                return this.narrativeField;
            }
            set
            {
                this.narrativeField = value;
            }
        }

        /// <remarks/>
        public uint PhoneNr
        {
            get
            {
                return this.phoneNrField;
            }
            set
            {
                this.phoneNrField = value;
            }
        }

        /// <remarks/>
        public string CustomerName
        {
            get
            {
                return this.customerNameField;
            }
            set
            {
                this.customerNameField = value;
            }
        }

        /// <remarks/>
        public string Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }
    }


}
