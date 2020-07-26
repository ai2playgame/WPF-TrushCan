﻿using PrismPRJ02.Core.Models;

namespace NavigationTree.ViewModels
{
    /// <summary>
    ///  WpfTestAppDataを木構造に加工する
    /// </summary>
    public class TreeViewItemCreator
    {
        internal static TreeViewItemViewModel Create(WpfTestAppData appData)
        {
            var rootNode = new TreeViewItemViewModel(appData.Student);
            var physicalClass = new TreeViewItemViewModel("身体測定");
            rootNode.Children.Add(physicalClass);

            foreach (var item in appData.Physicals)
            {
                var child = new TreeViewItemViewModel(item);
                physicalClass.Children.Add(child);
            }
 
            var testPointClass = new TreeViewItemViewModel("試験結果");
            rootNode.Children.Add(testPointClass);
 
            foreach (var item in appData.TestPoints)
            {
                var child = new TreeViewItemViewModel(item);
                testPointClass.Children.Add(child);
            }
 
            return rootNode;
        }
    }
}
