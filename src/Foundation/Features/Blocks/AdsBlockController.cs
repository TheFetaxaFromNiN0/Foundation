using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer.Web.Mvc;
using Foundation.Cms.Blocks;

namespace Foundation.Features.Blocks
{
    public class AdsBlockController: BlockController<AdsBlock>
    {
        public override ActionResult Index(AdsBlock currentBlock)
        {
            return PartialView("~/Features/Blocks/Views/AdsBlock.cshtml", currentBlock);
        }
    }
}