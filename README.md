# PlayListRipper
### PlayListRipper is a little tool I created to Download YouTube Videos and PlayLists.

#### This Project is Powered by [YouTubeExplode](https://github.com/Tyrrrz/YoutubeExplode), [YouTubeExplode.Converter](https://www.nuget.org/packages/YoutubeExplode.Converter) and [FFMPEG](https://ffmpeg.org)

## How it works
Once you run the program, you are prompted to select the type of Media you want to download (Video / PlayList / Channel), the options marked with (MP3) will download the given link as .mp3 files
## Where can I access my files?
The Files will be stored on `Desktop/PlayListRipper` in case you download a PlayList, they will be saved in `Desktop/PlayListRipper/PlayListName/`, if however you downloaded an entire channel, your files can be found in `Desktop/PlayListRipper/ChannelName/`
## What platform is this made for?
PlayListRipper currently only runs on Windows, a linux version will follow soon.

# IMPORTANT
Since this project is made using [YouTubeExplode.Converter](https://www.nuget.org/packages/YoutubeExplode.Converter) you will **need** [FFMPEG](https://ffmpeg.org) which can be downloaded [HERE](https://ffbinaries.com/downloads)
If you're unsure if you have `FFPMEG` installed, you can press `Win + R` and type `cmd`, inside of the command prompt you can try to type `ffmpeg`.
If you are using `Version 1.2` or above, you no longer need to download and install `FFMPEG`, you can run the program as administrator, and it will automatically check if ffmpeg is installed, and will ask the user if they want `PlayListRipper` to download and set it up for them.

### Example usage
![image](https://user-images.githubusercontent.com/61352968/168492164-b94594c9-c6fa-4fcd-9fec-cf0984cda6fa.png)

# How to install FFMPEG
### Step 1: Go to [this Website](https://ffbinaries.com/downloads) and download the latest FFMPEG version.
### Step 2: Create a folder in any directory, `C:/` for example and create a folder with any name, `ffmpeg` will be used for this example
### Step 3: Extract the contents of the in step 1 downloaded archive file, into the folder you just created, in this case it's `C:/ffmpeg/`
### Step 4: Press the `windows` key and type `"environment variables"` open the program.
![image](https://user-images.githubusercontent.com/61352968/168972566-789ae793-e389-4959-9abb-e31815ba361b.png)
### Step 5: Click on the `"Enviroment Variables"` button
![image](https://user-images.githubusercontent.com/61352968/168972805-b96eefbf-0a10-46ff-9c00-b00d84642959.png)
### Step 6: Find `Path` in `System variables`, click it once and then press `edit`
![image](https://user-images.githubusercontent.com/61352968/168973050-c1974133-eaa5-42c5-a911-f8630064fe22.png)
### Step 7: Click on new and type the path you have extracted the archive in, in this example `C:/ffmpeg`
![image](https://user-images.githubusercontent.com/61352968/168973482-97fc5e78-f0fb-4a1b-9575-f6cb84b8c168.png)
## Done.
#### If all steps are completed, you can open your `commnand prompt` and try to type `ffmpeg`, it should look similar to this:
![image](https://user-images.githubusercontent.com/61352968/168973704-08c0dde4-2fa8-4066-9be4-5bd5dbe1afb3.png)




