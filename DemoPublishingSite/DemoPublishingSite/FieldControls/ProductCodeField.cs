using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using TextBox = Microsoft.SharePoint.Mobile.Controls.TextBox;

namespace DemoPublishingSite.FieldControls
{
    public class ProductCodeField : BaseFieldControl
    {
        protected TextBox ProductCodeTextBox;
        protected RegularExpressionValidator ProductCodeValidator;
        protected HyperLink ProductCodeHyperLink;

        protected override string DefaultTemplateName
        {
            get { return "ProductCodeRenderingTemplate"; }

        }

        public override string DisplayTemplateName
        {
            get { return "ProductCodeDisplayRenderingTemplate"; }
        }

        public override object Value
        {
            get
            {
                this.EnsureChildControls();
                return ProductCodeTextBox.Text;
            }
            set
            {
                this.EnsureChildControls();
                ProductCodeTextBox.Text = (string)this.ItemFieldValue;
            }
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            if (this.ControlMode==SPControlMode.Display)
            {
                ProductCodeHyperLink = (HyperLink) this.TemplateContainer.FindControl("ProductCodeHyperLink");

                ProductCodeHyperLink.NavigateUrl=String.Format("{0}/Products?ProductCode={1}", SPContext.Current.Web.Url, (string)this.ItemFieldValue);

                ProductCodeHyperLink.Text = (string) this.ItemFieldValue;
            }

            else
            {
                ProductCodeTextBox = (TextBox) this.TemplateContainer.FindControl("ProductCodeTextBox");
                ProductCodeValidator =
                    (RegularExpressionValidator) this.TemplateContainer.FindControl("ProductCodeValidator");
            }
        }
    }
   
}
