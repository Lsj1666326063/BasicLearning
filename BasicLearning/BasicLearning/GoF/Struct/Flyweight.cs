using System;
using System.Collections.Generic;

namespace BasicLearning
{
    /*
     * 练习
        Sunny软件公司欲开发一个多功能文档编辑器，在文本文档中可以插入图片、动画、视频等多媒体资料，
        为了节约系统资源，相同的图片、动画和视频在同一个文档中只需保存一份，但是可以多次重复出现，
        而且它们每次出现时位置和大小均可不同。试使用享元模式设计该文档编辑器。
     */

    public class Document
    {
        public void InsertMultiMedia(DocMediaTransform transform, MultiMediaFlyweight multiMedia)
        {
            Console.WriteLine($"在Index为 {transform.Index} 的位置 插入 {multiMedia.Display(transform.Size)}");
        }
    }

    public class DocMediaTransform
    {
        public int Index;
        public int Size;

        public DocMediaTransform(int index, int size)
        {
            Index = index;
            Size = size;
        }
    }

    public abstract class MultiMediaFlyweight
    {
        public string Name;

        public MultiMediaFlyweight(string name)
        {
            Name = name;
        }
        public abstract string Display(int size);
    }
    
    public class Picture:MultiMediaFlyweight
    {
        public Picture(string name) : base(name){}
         
        public override string Display(int size)
        {
            return $"大小为 {size} 的图片 {Name}";
        }
    }

    public class Animate:MultiMediaFlyweight
    {
        public Animate(string name) : base(name){}
        
        public override string Display(int size)
        {
            return $"大小为 {size} 的动画 {Name}";
        }
    }

    public class Video:MultiMediaFlyweight
    {
        public Video(string name) : base(name){}
        
        public override string Display(int size)
        {
            return $"大小为 {size} 的视频 {Name}";
        }
    }
    

    public abstract class MultiMediaFactory
    {
        protected Dictionary<string,MultiMediaFlyweight> multiMedias = new Dictionary<string, MultiMediaFlyweight>();

        public abstract MultiMediaFlyweight Create(string name);
    }

    public class PictureFactory : MultiMediaFactory
    {
        public override MultiMediaFlyweight Create(string name)
        {
            if (multiMedias.ContainsKey(name))
                return multiMedias[name];
            MultiMediaFlyweight multiMedia = new Picture(name);
            multiMedias.Add(name,multiMedia);
            return multiMedia;
        }
    }

    public class AnimateFactory : MultiMediaFactory
    {
        public override MultiMediaFlyweight Create(string name)
        {
            if (multiMedias.ContainsKey(name))
                return multiMedias[name];
            MultiMediaFlyweight multiMedia = new Animate(name);
            multiMedias.Add(name,multiMedia);
            return multiMedia;
        }
    }

    public class VideoFactory : MultiMediaFactory
    {
        public override MultiMediaFlyweight Create(string name)
        {
            if (multiMedias.ContainsKey(name))
                return multiMedias[name];
            MultiMediaFlyweight multiMedia = new Video(name);
            multiMedias.Add(name,multiMedia);
            return multiMedia;
        }
    }
}