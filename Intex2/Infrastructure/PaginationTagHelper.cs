using Intex2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex2.Infrastructure
{
    
        //this helps us set up page links
        [HtmlTargetElement("div", Attributes = "page-model")]
        public class PaginationTagHelper : TagHelper
        {

            private IUrlHelperFactory uhf;
            public PaginationTagHelper (IUrlHelperFactory temp)
            {
                uhf = temp;
            }

            [ViewContext]
            [HtmlAttributeNotBound]
            public ViewContext vc { get; set; }


            //different than view context
            public PageInfo PageModel { get; set; }
            public string PageAction { get; set; }

            public string PageClass { get; set; }
            public bool PageClassesEnabled { get; set; }
            public string PageClassNormal { get; set; }
            public string PageClassSelected { get; set; }



            public override void Process(TagHelperContext thc, TagHelperOutput tho)
            {
                IUrlHelper uh = uhf.GetUrlHelper(vc);

                TagBuilder final = new TagBuilder("div");

            string sexFilter = PageModel.Sex ?? "z";
            string ageAtDeathFilter = PageModel.AgeAtDeath ?? "z";
            string hairColorFilter = PageModel.HairColor ?? "z";
            string wrappingFilter = PageModel.Wrapping ?? "z";
            string headDirectionFilter = PageModel.HeadDirection ?? "z";
            string depthFilter = PageModel.Depth ?? "";


            //this might have to be less than or equal to
            for (int i = 1; i <= PageModel.TotalPages; i++)
                {
                    TagBuilder tb = new TagBuilder("a");
                    tb.Attributes["href"] = uh.Action(PageAction, new { 
                        pageNum = i,
                        sex = sexFilter,
                        ageatdeath = ageAtDeathFilter,
                        haircolor = hairColorFilter,
                        wrapping = wrappingFilter,
                        headdirection = headDirectionFilter,
                        depth = depthFilter

                    });

                    if (PageClassesEnabled)
                    {
                        tb.AddCssClass(PageClass);
                        tb.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    }


                    tb.InnerHtml.Append(i.ToString());

                    final.InnerHtml.AppendHtml(tb);
                }

                tho.Content.AppendHtml(final.InnerHtml);


            }
        }
    }

