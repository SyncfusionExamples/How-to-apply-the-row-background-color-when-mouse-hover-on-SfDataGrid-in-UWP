using DataGridDemo;
using DataGridDemo.UWP;
using Syncfusion.SfDataGrid.XForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms.Platform.UWP;
using System.Reflection;
using System.Diagnostics;

[assembly: ExportRenderer(typeof(CustomStackLayout), typeof(CustomStackLayoutRenderer))]
namespace DataGridDemo.UWP
{
   public class CustomStackLayoutRenderer : VisualElementRenderer<CustomStackLayout, Control>
    {

        int previousIndex;

        DataRowBase rowdata;

        VirtualizingCellsControl wholeRowElement;

        SfDataGrid grid;

        Xamarin.Forms.Point point;
        public CustomStackLayoutRenderer()
        {
            this.PointerMoved += CustomStackLayoutRenderer_PointerMoved;
            this.PointerReleased += CustomStackLayoutRenderer_PointerReleased;
        }

        private void CustomStackLayoutRenderer_PointerReleased(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            var pointerPoint = e.GetCurrentPoint(this);
            point.Y = pointerPoint.Position.Y;
            point.X = pointerPoint.Position.X;
            var rowColumnIndex = SfDataGridHelpers.PointToCellRowColumnIndex(grid, point);
            var model = (GridModel)grid.GetType().GetRuntimeProperties().FirstOrDefault(x => x.Name.Equals("GridModel")).GetValue(grid);
            rowdata = SfDataGridHelpers.GetRowGenerator(grid).Items.FirstOrDefault(x => x.RowIndex == rowColumnIndex.RowIndex);
            if (rowdata != null)
            {
                wholeRowElement = (VirtualizingCellsControl)rowdata.GetType().GetRuntimeFields().FirstOrDefault(x => x.Name.Equals("WholeRowElement")).GetValue(rowdata);
                wholeRowElement.BackgroundColor = Xamarin.Forms.Color.White;
            }
        }

        private void CustomStackLayoutRenderer_PointerMoved(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            var pointerPoint = e.GetCurrentPoint(this);
            point.Y = pointerPoint.Position.Y;
            point.X = pointerPoint.Position.X;
            var rowColumnIndex = SfDataGridHelpers.PointToCellRowColumnIndex(grid, point);
            var model = (GridModel)grid.GetType().GetRuntimeProperties().FirstOrDefault(x => x.Name.Equals("GridModel")).GetValue(grid);
            if (previousIndex == rowColumnIndex.RowIndex)
            {

                rowdata = SfDataGridHelpers.GetRowGenerator(grid).Items.FirstOrDefault(x => x.RowIndex == rowColumnIndex.RowIndex);
                if (rowdata != null)
                {
                    wholeRowElement = (VirtualizingCellsControl)rowdata.GetType().GetRuntimeFields().FirstOrDefault(x => x.Name.Equals("WholeRowElement")).GetValue(rowdata);
                    wholeRowElement.BackgroundColor = Xamarin.Forms.Color.Red;
                }
            }
            else
            {
                rowdata = SfDataGridHelpers.GetRowGenerator(grid).Items.FirstOrDefault(x => x.RowIndex == previousIndex);
                if (rowdata != null)
                {
                    wholeRowElement = (VirtualizingCellsControl)rowdata.GetType().GetRuntimeFields().FirstOrDefault(x => x.Name.Equals("WholeRowElement")).GetValue(rowdata);
                    wholeRowElement.BackgroundColor = Xamarin.Forms.Color.White;
                }
            }
            previousIndex = rowColumnIndex.RowIndex;

        }

        protected override void OnElementChanged(ElementChangedEventArgs<CustomStackLayout> e)
        {
            base.OnElementChanged(e);
            grid = this.Element.Children[0] as SfDataGrid;
            grid.GridTapped += Grid_GridTapped;
            point = new Xamarin.Forms.Point();

        }

        private void Grid_GridTapped(object sender, GridTappedEventArgs e)
        {
            wholeRowElement = (VirtualizingCellsControl)rowdata.GetType().GetRuntimeFields().FirstOrDefault(x => x.Name.Equals("WholeRowElement")).GetValue(rowdata);
            wholeRowElement.BackgroundColor = Xamarin.Forms.Color.Blue;
        }
    }
}
