﻿using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DangKy: MonoBehaviour
{
    public TMP_InputField inputUsername, inputPassword, inputEmail, inputCharacterName, inputMobilePhone;
    public Button btnDangKy, btnDangNhap;

    public TMP_Text check;
    public GameObject errorScrollbar;
    public GameObject panelDangKy, panelDangNhap;
    static string fileName = "account.txt";


    private void Start()
    {
        
        panelDangNhap.SetActive(true);
        panelDangKy.SetActive(false);
        //errorScrollbar.SetActive(false);
        btnDangKy.onClick.AddListener(() => layDuLieuNhapVao());
        btnDangNhap.onClick.AddListener(()=>loadScreenDangNhap());

    }

    public void layDuLieuNhapVao()
    {

        string username = inputUsername.text.Trim();
        string password = inputPassword.text.Trim();
        string email = inputEmail.text.Trim();
        string characterName = inputCharacterName.text.Trim();
        string mobilePhone = inputMobilePhone.text.Trim();
        if (!Regex.IsMatch(username, "^[a-z0-9]{1,20}$"))
        {
            check.text = "Username chỉ gồm chữ thường và số, tối đa 20 ký tự.";
            return;
        }
        if (!Regex.IsMatch(password, @"^(?=.*[a-zA-Z])(?=.*\d).{6,20}$"))
        {
            check.text = "Password phải có chữ, số, ký tự @#$%, từ 6-20 ký tự.";
            return;
        }
        if (!Regex.IsMatch(email, @"^[\w\.-]+@[\w\.-]+\.\w+$"))
        {
            check.text = "Email không hợp lệ!";
            return;
        }
        if (characterName.Length > 15)
        {
            check.text = "Tên nhân vật không quá 15 ký tự.";
            return;
        }
        if (!Regex.IsMatch(mobilePhone, @"^(0[3|5|7|8|9])+([0-9]{8})$"))
        {
            check.text = "Số điện thoại không hợp lệ!";
            return;
        }
        using (StreamWriter writer = new StreamWriter("account.txt", true))
        {

            writer.WriteLine($"{username}\t{password}\t{email}\t{characterName}\t{mobilePhone}");
        }
        check.text = "Đăng ký thành công!";
        show();
        //panelDangKy.SetActive(false);
        //panelDangNhap.SetActive(true);

    }

    public void loadScreenDangNhap()
    {
        panelDangKy.SetActive(false);
        panelDangNhap.SetActive(true);
    }
    public void show()
    {
        errorScrollbar.SetActive(true);
        Invoke("HideScrollBar", 3f);
    }
    void HideScrollBar()
    {
        errorScrollbar.SetActive(false);
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
