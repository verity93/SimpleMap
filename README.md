SimpleMap is an AMAZING (FOSS) open-source, fully managed code implementation of a GIS engine for desktop, easily ported to mobile and web.

It is a fully managed dot net core codebase, compact and easy to use.

This is a fully working Visual Studio C# sample project, please help to add more features like georeferencing.

Full FOSS source code, sample compiles and demonstrates how You can use maps in your projects.

## Features

 - All in one Winform control

 - No un-managed Code & No Dependencies.

 - Small code size

 - Lightweight

## Rendering

 - Fast image draw to screen via GDI+, written pure on C# without any direct mapping to WinApi.

 - Double buffering technology, all image changes draw into memory buffer and then changes apply to the screen.

## Tile servers

 - Download map images from tile servers (e.g google).

 - Cache map tile on disk.

 - Download google image file cache to local storage.

 - Save google Maps as one image.

 - Base classes to draw any map layers.

 ## Georeference 
 
 **New Feature/ Work in progress**
 
 - Raster Image loader  
 - Georeference image to create world file

 - Load raster image (pngw,bmpw,jpgw,tifw, etc) as geo referenced overlay

## GIS Projection

 - Projection of coordinate system through subclasses and operators.

 - Translate google coordinates to longitude and latitude.

 - Translate longitude and latitude to google coordinates.

 - Math operators support working with coordinates.

 - Spatial in-memory index with fast search by coordinates based on google map coordinate system.

 - Spatial index tuning.

 - Spatial index supported objects are: 
 
    - Point, Line, Rectangle, Polygon(partially supported).

SimpleMap/ExampleForms/FrmMapDownloader.cs demonstrates how to download google map area as single image (GetFullMapThread function) or how to cache google map on local disk (DownloadThread function).

SimpleMap/ExampleForms/Controls/MapCtl.cs demonstrates how to draw cached google map images to screen with custom objects as lines, bitmaps etc.

**It is absolutely free for use.**  Please fork or contribute and help improve.
