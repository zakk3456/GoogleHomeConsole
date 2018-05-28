using Codeplex.Data;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoogleHomeConsole
{
    public partial class Main : System.Web.UI.Page
    {
        /// <summary>
        /// ページロードイベント
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["NgrokDomain"] = GetNgrokDomain();
            }
        }

        /// <summary>
        /// 喋らせるボタン押下イベント
        /// </summary>
        protected void BtnSay_Click(object sender, EventArgs e)
        {
            var say = this.tbxSay.Text.Trim();
            SayGoogleHome(say);
        }

        /// <summary>
        /// 汎用ボタン押下イベント
        /// </summary>
        protected void CommonButtons_Click(object sender, EventArgs e)
        {
            if (!(sender is Button btn))
            {
                return;
            }

            //ボタンの文字を喋らせる
            var say = btn.Text.Trim();
            SayGoogleHome(say);
        }

        /// <summary>
        /// GoogleHomeを喋らせる
        /// </summary>
        /// <param name="say">喋らせる内容</param>
        private void SayGoogleHome(string say)
        {
            var ngrokDomainSession = Session["NgrokDomain"];
            string ngrokDomain = ngrokDomainSession == null ? GetNgrokDomain() : (string)ngrokDomainSession;
            var url = string.Format("{0}/google-home-notifier", ngrokDomain);
            var enc = System.Text.Encoding.UTF8;

            //POST送信する文字列を作成
            string postData = string.Format("text={0}", HttpUtility.UrlEncode(say, enc));

            using (var wc = new WebClient())
            {
                //文字コードを指定する
                wc.Encoding = enc;
                //ヘッダにContent-Typeを加える
                wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                //データを送信し、また受信する
                string resText = wc.UploadString(url, postData);

                this.lblResult.Text = resText;

                //入力した文字をクリアする
                this.tbxSay.Text = string.Empty;
            }
        }

        /// <summary>
        /// ngrokのドメインを取得する
        /// </summary>
        /// <returns>取得したドメイン</returns>
        private string GetNgrokDomain()
        {
            string storageConnectionString = Properties.Settings.Default.StorageConnectionString;
            var storageAccount = CloudStorageAccount.Parse(storageConnectionString);

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("settings");
            TableOperation retrieveOperation = TableOperation.Retrieve<SettingEntity>("ngrok", "domain");
            TableResult retrievedResult = table.Execute(retrieveOperation);

            string ngrokDomain = string.Empty;
            if (retrievedResult.Result != null)
            {
                ngrokDomain = ((SettingEntity)retrievedResult.Result).Value;
            }

            lblNgrokDomain.Text = ngrokDomain;

            return ngrokDomain;
        }
    }
}