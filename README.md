<style>
    .title { color: #ff8000 }
    .middle {
        position: relative;
        vertical-align: middle;
        display: inline-block;
    }
</style>

<h1 class="title">
    <div class="middle">
        ![Thunderfury](.github/inv_sword_39.jpg)
    </div>
    <span class="middle">Thunderfury, Blessed Blade of the Windseeker
</h1>

## Building

Before buildings, there are several partial classes whose job
is to hold private data that remains unversioned. Generally speaking,
you can locate them by looking for `*.cs` and `*.example` pairs.

Before building, you'll need to take these `*.example` files, copy them
into `*.private.cs` files and fill out their info.

The current, non-exhaustive list of these files includes:
- `thunderfury.common/Constants.cs`

## Structure

```
(workdir)
|- .github // Files for GitHub use
|- thunderfury.common           // API and business logic
|- thunderfury.common.tests
|- thunderfury.android          // Android 4.1+ app
|- thunderfury.android.tests
|- thunderfury.ios              // iOS 9+ app
|- thunderfury.ios.tests
|- thunderfury.uwp              // Windows 10 UWP
|- thunderfury.uwp.tests
|- thunderfury.osx              // macOS 10.11+ app
|- thunderfury.osx.tests
|- thunderfury.wpf              // Windows WPF app
`- thunderfury.wpf.tests
```

Projects should also each have a `README` describing gotchas and
project-specific needs.