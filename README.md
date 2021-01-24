
# ConfigTableCSharp

ConfigTable's csharp runtime library. [Check config compiler tool here](https://github.com/wlgys8/ms-config-compiler)


ConfigTable的csharp运行库. [配置表编译工具请看这里](https://github.com/wlgys8/ms-config-compiler)



# Warning 

In developing, API maybe unstable.

项目处于开发中，功能接口可能不稳定

# Install

add follow to Package/manifest.json

```
"com.ms.configtable":"https://github.com/wlgys8/ConfigTableCSharp.git"
```

# Quick Usage


- first, use config compiler tool to generate codes and binary data files from excel.

- then put these files into unity project

- load configs use following codes:


```csharp

using(var tableLoader = MergedTableLoader.FromFile("Path/Of/ConfigData.bytes","Path/Of/Manifest.json")){
    var table1 = tableLoader.LoadTable<TestConfig1Table>();
    Debug.Log(table1[0]); //get the item which type is TestConfig

    var table2 = tableLoader.LoadTable<TestConfig2Table>();
    Debug.Log(table2[0]); //get the item which type is TestConfig2
}

```


if you generate a binary file for each excel file, then you can load it with following code:

```csharp

var table = new TestConfigTable();
table.FromResources("ResourcesPath/To/File");

```


# More

## MS.Config.Table

For configs that without keys, the generated `ConfigTable` always inherit from `MS.Config.Table<V>`.

elements in Table can only be visited by number index.

## MS.Config.TableDict

For configs that with key(s),the generated `ConfigTable` will inherit from `MS.Config.TableDict<K,V>`.

Elements in Table can be visited either by key, or by number index.

If the primary key is composite, the struct `Config.TableDict<K,V>.Key` can be used to index elements.




