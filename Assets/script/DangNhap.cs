using System.Collections.Generic;
using System.IO;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DangNhap : MonoBehaviour
{
    public TMP_InputField username, password;
    public Button btnDangNhap, btnDangKy;
    public GameObject panelDangKy, panelDangNhap;
    public GameObject errorScrollbar;
    public TMP_Text check;
    static string fileName = "account.txt";
    private void Start()
    {
        panelDangNhap.SetActive(true);
        btnDangKy.onClick.AddListener(() => loadScreen());
        btnDangNhap.onClick.AddListener(() => KiemTraDangNhap());



    }
    public void loadScreen()
    {
        panelDangKy.SetActive(true);
        panelDangNhap.SetActive(false);
    }
    public void KiemTraDangNhap()
    {
        string userName = username.text.Trim();
        string passWord = password.text.Trim();

        List<account> accounts = loadFile(fileName);

        Debug.Log("Tổng số tài khoản: " + accounts.Count);
        foreach (var acc in accounts)
        {
            Debug.Log($"Kiểm tra: {acc.username} - {acc.password}");
            if (acc.username == userName && acc.password == passWord)
            {
                check.text = "Đăng nhập thành công!";
                return;
            }
        }
        check.text = "Sai tài khoản hoặc mật khẩu!";
    }
    static List<account> loadFile(string file)
    {
        List<account> accountList = new List<account>();

        if (!File.Exists(file))
        {
            return accountList;
        }

        using (StreamReader reader = new StreamReader(file, Encoding.UTF8))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split('\t');
                if (data.Length == 5)
                {
                    accountList.Add(new account(data[0], data[1], data[2], data[3], data[4]));
                }
            }
        }

        return accountList;
    }


    class account
    {
        public string username;
        public string password;
        public string email;
        public string characterName;
        public string mobilePhone;

        public account(string username, string password, string email, string characterName, string mobilePhone)
        {
            this.username = username;
            this.password = password;
            this.email = email;
            this.characterName = characterName;
            this.mobilePhone = mobilePhone;
        }


        //, password, email, characterName, mobilePhone
    }

}
