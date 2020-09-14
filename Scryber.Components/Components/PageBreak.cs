﻿/*  Copyright 2012 PerceiveIT Limited
 *  This file is part of the Scryber library.
 *
 *  You can redistribute Scryber and/or modify 
 *  it under the terms of the GNU Lesser General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 * 
 *  Scryber is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU Lesser General Public License for more details.
 * 
 *  You should have received a copy of the GNU Lesser General Public License
 *  along with Scryber source code in the COPYING.txt file.  If not, see <http://www.gnu.org/licenses/>.
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;
using Scryber.Styles;


namespace Scryber.Components
{
    [PDFParsableComponent("PageBreak")]
    public class PageBreak : VisualComponent, IPDFLayoutBreak
    {

        public LayoutBreakType BreakType
        {
            get { return LayoutBreakType.Page; }
        }

        public PageBreak()
            : base(PDFObjectTypes.PageBreak)
        {
        }


        protected override PDFStyle GetBaseStyle()
        {
            var style = base.GetBaseStyle();
            
            return style;
        }
    }
}
