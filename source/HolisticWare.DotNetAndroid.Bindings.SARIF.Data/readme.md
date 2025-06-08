# Logging

Given errors and warnings from the build process of the Maven Artifact

```
./generated/com.google.auto.value.auto-value/obj/Release/net8.0-android/generated/src/Google.AutoValue.Common.Collect.ImmutableSortedSet.cs(1059,84): error CS0111: Type 'ImmutableSortedSet' already defines a member called 'Of' with the same parameter types [./generated/com.google.auto.value.auto-value/com.google.auto.value.auto-value.csproj::TargetFramework=net8.0-android]
./generated/com.google.auto.value.auto-value/obj/Release/net8.0-android/generated/src/Google.AutoValue.Common.Collect.MultimapBuilder.cs(634,80): error CS0533: 'MultimapBuilder.SortedSetMultimapBuilder.Build()' hides inherited abstract member 'MultimapBuilder.SetMultimapBuilder.Build()' [./generated/com.google.auto.value.auto-value/com.google.auto.value.auto-value.csproj::TargetFramework=net8.0-android]
./generated/com.google.auto.value.auto-value/obj/Release/net8.0-android/generated/src/Google.AutoValue.Common.Collect.MultimapBuilder.cs(674,81): error CS0508: 'MultimapBuilder.SortedSetMultimapBuilderInvoker.Build()': return type must be 'ISortedSetMultimap' to match overridden member 'MultimapBuilder.SortedSetMultimapBuilder.Build()' [./generated/com.google.auto.value.auto-value/com.google.auto.value.auto-value.csproj::TargetFramework=net8.0-android]
./generated/com.google.auto.value.auto-value/obj/Release/net8.0-android/generated/src/Google.AutoValue.Common.Collect.MultimapBuilder.cs(687,78): error CS0508: 'MultimapBuilder.SortedSetMultimapBuilderInvoker.Build()': return type must be 'ISortedSetMultimap' to match overridden member 'MultimapBuilder.SortedSetMultimapBuilder.Build()' [./generated/com.google.auto.value.auto-value/com.google.auto.value.auto-value.csproj::TargetFramework=net8.0-android]
./generated/com.google.auto.value.auto-value/obj/Release/net8.0-android/generated/src/Google.AutoValue.Common.Collect.MultimapBuilder.cs(639,26): error CS0534: 'MultimapBuilder.SortedSetMultimapBuilderInvoker' does not implement inherited abstract member 'MultimapBuilder.Build()' [./generated/com.google.auto.value.auto-value/com.google.auto.value.auto-value.csproj::TargetFramework=net8.0-android]
./generated/com.google.auto.value.auto-value/obj/Release/net8.0-android/generated/src/Google.AutoValue.Common.Collect.MultimapBuilder.cs(639,26): error CS0534: 'MultimapBuilder.SortedSetMultimapBuilderInvoker' does not implement inherited abstract member 'MultimapBuilder.SetMultimapBuilder.Build()' [./generated/com.google.auto.value.auto-value/com.google.auto.value.auto-value.csproj::TargetFramework=net8.0-android]
./generated/com.google.auto.value.auto-value/obj/Release/net8.0-android/generated/src/Google.AutoValue.Common.Collect.MultimapBuilder.cs(674,81): error CS0111: Type 'MultimapBuilder.SortedSetMultimapBuilderInvoker' already defines a member called 'Build' with the same parameter types [./generated/com.google.auto.value.auto-value/com.google.auto.value.auto-value.csproj::TargetFramework=net8.0-android]
./generated/com.google.auto.value.auto-value/obj/Release/net8.0-android/generated/src/Google.AutoValue.Common.Collect.MultimapBuilder.cs(687,78): error CS0111: Type 'MultimapBuilder.SortedSetMultimapBuilderInvoker' already defines a member called 'Build' with the same parameter types [./generated/com.google.auto.value.auto-value/com.google.auto.value.auto-value.csproj::TargetFramework=net8.0-android]
./generated/com.google.auto.value.auto-value/obj/Release/net8.0-android/generated/src/Google.AutoValue.Common.Collect.LinkedHashMultiset.cs(337,57): error CS0111: Type 'LinkedHashMultiset' already defines a member called 'ElementSet' with the same parameter types [./generated/com.google.auto.value.auto-value/com.google.auto.value.auto-value.csproj::TargetFramework=net8.0-android]
./generated/com.google.auto.value.auto-value/obj/Release/net8.0-android/generated/src/Google.AutoValue.Common.Collect.LinkedHashMultiset.cs(247,57): error CS0111: Type 'LinkedHashMultiset' already defines a member called 'EntrySet' with the same parameter types [./generated/com.google.auto.value.auto-value/com.google.auto.value.auto-value.csproj::TargetFramework=net8.0-android]
./generated/com.google.auto.value.auto-value/obj/Release/net8.0-android/generated/src/Google.AutoValue.Common.Collect.LinkedHashMultiset.cs(259,22): error CS0111: Type 'LinkedHashMultiset' already defines a member called 'ForEachEntry' with the same parameter types [./generated/com.google.auto.value.auto-value/com.google.auto.value.auto-value.csproj::TargetFramework=net8.0-android]
./generated/com.google.auto.value.auto-value/obj/Release/net8.0-android/generated/src/Google.AutoValue.Common.Collect.LinkedHashMultiset.cs(273,55): error CS0111: Type 'LinkedHashMultiset' already defines a member called 'Iterator' with the same parameter types [./generated/com.google.auto.value.auto-value/com.google.auto.value.auto-value.csproj::TargetFramework=net8.0-android]
./generated/com.google.auto.value.auto-value/obj/Release/net8.0-android/generated/src/Google.AutoValue.Common.Collect.LinkedListMultimap.cs(22,70): error CS0738: 'LinkedListMultimap' does not implement interface member 'IMultimap.Get(Object?)'. 'LinkedListMultimap.Get(Object?)' cannot implement 'IMultimap.Get(Object?)' because it does not have the matching return type of 'ICollection'. [./generated/com.google.auto.value.auto-value/com.google.auto.value.auto-value.csproj::TargetFramework=net8.0-android]
./generated/com.google.auto.value.auto-value/obj/Release/net8.0-android/generated/src/Google.AutoValue.Common.Collect.LinkedListMultimap.cs(22,70): error CS0738: 'LinkedListMultimap' does not implement interface member 'IMultimap.RemoveAll(Object?)'. 'LinkedListMultimap.RemoveAll(Object?)' cannot implement 'IMultimap.RemoveAll(Object?)' because it does not have the matching return type of 'ICollection'. [./generated/com.google.auto.value.auto-value/com.google.auto.value.auto-value.csproj::TargetFramework=net8.0-android]
```

```
./generated/com.google.auto.value.auto-value/obj/Release/net8.0-android/generated/src/Google.AutoValue.Common.Collect.LinkedListMultimap.cs
(22,70): 
error CS0738: 
    'LinkedListMultimap' 
does not implement interface member 
    'IMultimap.Get(Object?)'. 
    'LinkedListMultimap.Get(Object?)'
cannot implement 
    'IMultimap.Get(Object?)'
because it does not have the matching return type of 
    'ICollection'. 
[./generated/com.google.auto.value.auto-value/com.google.auto.value.auto-value.csproj::TargetFramework=net8.0-android]
```


ErrorLog
Specify a file to log all compiler and analyzer diagnostics.

```xml
<ErrorLog>compiler-diagnostics.sarif</ErrorLog>
```

https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-options/errors-warnings#errorlog

https://github.com/dotnet/sdk/issues/43269

https://github.com/microsoft/sarif-sdk

https://github.com/microsoft/sarif-sdk/blob/main/src/Sarif/Schemata/sarif-2.1.0-rtm.6.json

https://github.com/Microsoft/sarif-sdk/tree/main/src/Sarif/Autogenerated

> Sarif.Sdk depends on Newtonsoft.Json, which is installed automatically when you install Sarif.Sdk.

