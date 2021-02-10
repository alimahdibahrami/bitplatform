﻿using Bunit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Threading.Tasks;

namespace Bit.Client.Web.BlazorUI.Tests.Link
{
    [TestClass]
    public class BitLinkTests: BunitTestContext
    {
        [DataTestMethod, DataRow("fakelink.com", "a"),DataRow("","button")]
        public async Task BitLinkShouldRenderExpectedElementBaseOnHref(string href, string expectedElement)
        {
            var component = RenderComponent<BitLinkTest>(parameters => parameters.Add(p => p.Href, href));

            var bitLink = component.Find(".bit-link");
            var tagName = bitLink.TagName.ToLowerInvariant();

            Assert.AreEqual(expectedElement, tagName);
        }

        [TestMethod]
        public async Task BitLinkButton_OnClick_CounterValueEqualOne()
        {
            var component = RenderComponent<BitLinkButtonTest>();

            var bitLinkButton = component.Find("button.bit-link");
            bitLinkButton.Click();

            Assert.AreEqual(1, component.Instance.CurrentCount);
        }
    }
}
