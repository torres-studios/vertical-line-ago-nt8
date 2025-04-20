#region Using declarations
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Serialization;
using NinjaTrader.Cbi;
using NinjaTrader.Gui;
using NinjaTrader.Gui.Chart;
using NinjaTrader.Gui.SuperDom;
using NinjaTrader.Gui.Tools;
using NinjaTrader.Data;
using NinjaTrader.NinjaScript;
using NinjaTrader.Core.FloatingPoint;
using NinjaTrader.NinjaScript.DrawingTools;
#endregion

//This namespace holds Indicators in this folder and is required. Do not change it. 
namespace NinjaTrader.NinjaScript.Indicators.TorresStudios.VerticalLineAgo
{
	public class VerticalLineAgo : Indicator
	{
		protected override void OnStateChange()
		{
			if (State == State.SetDefaults)
			{
				Description									= @"Draws a single vertical line at a specified “bars ago” offset on your price panel.";
				Name										= "VerticalLineAgo";
				Calculate									= Calculate.OnBarClose;
				IsOverlay									= true;
				DisplayInDataBox							= false;
				DrawOnPricePanel							= true;
				DrawHorizontalGridLines						= true;
				DrawVerticalGridLines						= true;
				PaintPriceMarkers							= true;
				ScaleJustification							= NinjaTrader.Gui.Chart.ScaleJustification.Right;
				//Disable this property if your indicator requires custom values that cumulate with each new market data event. 
				//See Help Guide for additional information.
				IsSuspendedWhileInactive					= true;

				BarsAgo					= 20;
				LineColor					= Brushes.Blue;
				DashStyle					= DashStyleHelper.Solid;
				StrokeThickness					= 1;
			}
			else if (State == State.Configure)
			{
			}
		}

		protected override void OnBarUpdate()
		{
            // don't do anything until we have enough bars
            if (CurrentBar < BarsAgo)
                return;

            // remove the previous line so we only ever see one
            RemoveDrawObject("MyVLine");

            // draw a new vertical line BarsAgo bars back from the current bar
            Draw.VerticalLine(
                this,
                tag: "MyVLine",
                barsAgo: BarsAgo,
                brush: LineColor,
                dashStyle: DashStyle,
                width: StrokeThickness
            );
        }

		#region Properties
		[NinjaScriptProperty]
		[Range(1, int.MaxValue)]
		[Display(Name="BarsAgo", Description="Numbers of bars ago at which the line should be drawn", Order=1, GroupName="Parameters")]
		public int BarsAgo
		{ get; set; }

		[NinjaScriptProperty]
		[XmlIgnore]
		[Display(Name="LineColor", Description="The color of the line to be drawn", Order=2, GroupName="Parameters")]
		public Brush LineColor
		{ get; set; }

		[Browsable(false)]
		public string LineColorSerializable
		{
			get { return Serialize.BrushToString(LineColor); }
			set { LineColor = Serialize.StringToBrush(value); }
		}			

		[NinjaScriptProperty]
		[Display(Name="DashStyle", Description="The style of the line to be drawn", Order=3, GroupName="Parameters")]
		public DashStyleHelper DashStyle
		{ get; set; }

		[NinjaScriptProperty]
		[Range(1, int.MaxValue)]
		[Display(Name="StrokeThickness", Description="The thickness of the vertical line", Order=4, GroupName="Parameters")]
		public int StrokeThickness
		{ get; set; }
		#endregion

	}
}

#region NinjaScript generated code. Neither change nor remove.

namespace NinjaTrader.NinjaScript.Indicators
{
	public partial class Indicator : NinjaTrader.Gui.NinjaScript.IndicatorRenderBase
	{
		private TorresStudios.VerticalLineAgo.VerticalLineAgo[] cacheVerticalLineAgo;
		public TorresStudios.VerticalLineAgo.VerticalLineAgo VerticalLineAgo(int barsAgo, Brush lineColor, DashStyleHelper dashStyle, int strokeThickness)
		{
			return VerticalLineAgo(Input, barsAgo, lineColor, dashStyle, strokeThickness);
		}

		public TorresStudios.VerticalLineAgo.VerticalLineAgo VerticalLineAgo(ISeries<double> input, int barsAgo, Brush lineColor, DashStyleHelper dashStyle, int strokeThickness)
		{
			if (cacheVerticalLineAgo != null)
				for (int idx = 0; idx < cacheVerticalLineAgo.Length; idx++)
					if (cacheVerticalLineAgo[idx] != null && cacheVerticalLineAgo[idx].BarsAgo == barsAgo && cacheVerticalLineAgo[idx].LineColor == lineColor && cacheVerticalLineAgo[idx].DashStyle == dashStyle && cacheVerticalLineAgo[idx].StrokeThickness == strokeThickness && cacheVerticalLineAgo[idx].EqualsInput(input))
						return cacheVerticalLineAgo[idx];
			return CacheIndicator<TorresStudios.VerticalLineAgo.VerticalLineAgo>(new TorresStudios.VerticalLineAgo.VerticalLineAgo(){ BarsAgo = barsAgo, LineColor = lineColor, DashStyle = dashStyle, StrokeThickness = strokeThickness }, input, ref cacheVerticalLineAgo);
		}
	}
}

namespace NinjaTrader.NinjaScript.MarketAnalyzerColumns
{
	public partial class MarketAnalyzerColumn : MarketAnalyzerColumnBase
	{
		public Indicators.TorresStudios.VerticalLineAgo.VerticalLineAgo VerticalLineAgo(int barsAgo, Brush lineColor, DashStyleHelper dashStyle, int strokeThickness)
		{
			return indicator.VerticalLineAgo(Input, barsAgo, lineColor, dashStyle, strokeThickness);
		}

		public Indicators.TorresStudios.VerticalLineAgo.VerticalLineAgo VerticalLineAgo(ISeries<double> input , int barsAgo, Brush lineColor, DashStyleHelper dashStyle, int strokeThickness)
		{
			return indicator.VerticalLineAgo(input, barsAgo, lineColor, dashStyle, strokeThickness);
		}
	}
}

namespace NinjaTrader.NinjaScript.Strategies
{
	public partial class Strategy : NinjaTrader.Gui.NinjaScript.StrategyRenderBase
	{
		public Indicators.TorresStudios.VerticalLineAgo.VerticalLineAgo VerticalLineAgo(int barsAgo, Brush lineColor, DashStyleHelper dashStyle, int strokeThickness)
		{
			return indicator.VerticalLineAgo(Input, barsAgo, lineColor, dashStyle, strokeThickness);
		}

		public Indicators.TorresStudios.VerticalLineAgo.VerticalLineAgo VerticalLineAgo(ISeries<double> input , int barsAgo, Brush lineColor, DashStyleHelper dashStyle, int strokeThickness)
		{
			return indicator.VerticalLineAgo(input, barsAgo, lineColor, dashStyle, strokeThickness);
		}
	}
}

#endregion
