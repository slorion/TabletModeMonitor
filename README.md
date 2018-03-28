# Tablet Mode Monitor

With a 4K laptop display, everything is so small in Windows 10 tablet mode that it is basically unusable.
As far as I know, there is no built-in way to automatically change the DPI scaling or display resolution depending the current mode.
Neither have I found an utility that let me do just that, so I wrote one.
Setting and immediately applying the DPI scaling programmatically proved a bit difficult, so I opted to change the resolution instead.

This utility lets a user specify different display resolutions for desktop or tablet mode. When the mode changes, it sets the display resolution accordingly.