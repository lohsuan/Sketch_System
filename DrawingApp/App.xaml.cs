using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace DrawingApp
{
    /// <summary>
    /// 提供應用程式專屬行為以補充預設的應用程式類別。
    /// </summary>
    sealed partial class App : Application
    {
        private const string FAIL_TO_LOAD_PAGE = "Failed to load Page ";

        /// <summary>
        /// 初始化單一應用程式物件。這是第一行執行之撰寫程式碼，
        /// 而且其邏輯相當於 main() 或 WinMain()。
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += HandleOnSuspending;
        }

        /// <summary>
        /// 在應用程式由終端使用者正常啟動時叫用。當啟動應用
        /// 將在例如啟動應用程式時使用以開啟特定檔案。
        /// </summary>
        /// <param name="e">關於啟動要求和處理序的詳細資料。</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            // 當視窗中已有內容時，不重複應用程式初始化，只確定視窗是作用中
            rootFrame = ConfirmWindows(e, rootFrame);

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // 在巡覽堆疊未還原時，巡覽至第一頁，設定新的頁面，方式是透過傳遞必要資訊做為巡覽參數
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                Window.Current.Activate(); // 確定目前視窗是作用中
            }
        }

        // ConfirmWindows 當視窗中已有內容時，不重複應用程式初始化，只確定視窗是作用中
        private Frame ConfirmWindows(LaunchActivatedEventArgs e, Frame rootFrame)
        {
            if (rootFrame == null)
            {
                // 建立框架做為巡覽內容，並巡覽至第一頁
                rootFrame = new Frame();
                rootFrame.NavigationFailed += HandleOnNavigationFailed;
                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: 從之前暫停的應用程式載入狀態
                }
                Window.Current.Content = rootFrame; // 將框架放在目前視窗中
            }

            return rootFrame;
        }

        /// <summary>
        /// 在巡覽至某頁面失敗時叫用
        /// </summary>
        /// <param name="sender">導致巡覽失敗的框架</param>
        /// <param name="e">有關巡覽失敗的詳細資料</param>
        void HandleOnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception(FAIL_TO_LOAD_PAGE + e.SourcePageType.FullName);
        }

        /// <summary>
        /// 在應用程式暫停執行時叫用。應用程式狀態會儲存起來，
        /// 但不知道應用程式即將結束或繼續，而且仍將記憶體
        /// 的內容保持不變。
        /// </summary>
        /// <param name="sender">暫停之要求的來源。</param>
        /// <param name="e">有關暫停之要求的詳細資料。</param>
        private void HandleOnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: 儲存應用程式狀態，並停止任何背景活動
            deferral.Complete();
        }
    }
}
