# App「booklist」

## 概要

本の一覧を管理するCRUDシステムです。  
読みたい本や読んだ本を記録しておくことができます。

![preview](https://github.com/kondo-akihiro-git/practice-blazor-booklist/assets/139307918/9e976ffc-8821-4ca0-8f83-225a3f3d817c)

## 機能

- ログイン機能
- CRUD機能

## インストールと使い方

1. Visual Studioをインストールする。  
2. パッケージマネージャーで以下をインストールする。  
  ```Install-Package -ProjectName BlazorApp.Server -Id Microsoft.EntityFrameworkCore.SqlServer```  
  ```Install-Package -ProjectName BlazorApp.Server -Id Microsoft.EntityFrameworkCore.Tools```  
3. パッケージマネージャーで```Add-Migration -Name Initial -Context AppDbContext```を行う。  
4. デバッグ実行する。
   
   実行できなかった場合、以下の手段を参考にする。  
   ・ApplicationDbContext(ASP.NET Core IdentityのContextファイル)を```Add -Migration {Context}```する。  
   ・AntDesignをインストールする。  
   ```Install-Package -ProjectName BlazorApp.Client -Id AntDesign```

## 参考資料
https://github.com/tamtamyarn/BlazorApp6.0
