ObjLoader
========

Objloader is a simple Wavefront .obj and .mtl loader

Changes
-------
Agora, ao ter as tags "o", "g", "usemtl" sem conteúdo, não será mais lançado uma exception.
<br> Data da Versão: 2024-03-30

Agora os arquivos .obj e .mtl são independentes, cada um tem uma classe de carregamento(load) e de resultado (loadResult).
<br>Agora, os grupos são criados considerando as tags "o" "g" "usemtl", quando cada uma aparecer, será gerado um novo grupo, mantendo o contudo das outras tags.
<br> Agora, os vértices suportam atributos de cores.
<br> Adicionado suporte para linhas.
<br> Data da Versão: 2023-10-12


Installation 
------------
Build the project and reference the .dll or reference the project directly as usual.

Loading a model
---------------
Loading a .obj file:

	var loaderFactory = new ObjLoader.Loader.Loaders.ObjLoaderFactory();
    var objLoader = loaderFactory.Create();
    var fileStream = new FileInfo("file.obj").OpenRead();
    StreamReader streamReader = new StreamReader(fileStream, Encoding.ASCII);
    var objResult = objLoader.Load(streamReader);

    
Loading a .mtl file:

    var mtlLoaderFactory = new ObjLoader.Loader.Loaders.MtlLoaderFactory();
    var mtlLoader = mtlLoaderFactory.Create();
    var fileStreamMtl = new FileInfo("file.mtl").OpenRead();
    StreamReader streamReaderMtl = new StreamReader(fileStreamMtl, Encoding.ASCII);
    var mtlResult = mtlLoader.Load(streamReaderMtl);


The result object contains the loaded model in this form:
	
    public class LoadResult  
    {
        public IList<Vertex> Vertices { get; set; }
        public IList<Texture> Textures { get; set; }
        public IList<Normal> Normals { get; set; }
        public IList<Group> Groups { get; set; }
        public IList<string> Mtllibs { get; set; }
    }

    public class LoadResultMtl 
    {
        public IList<Material> Materials { get; set; }
    }
