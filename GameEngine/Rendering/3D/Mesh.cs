using GameEngine.EntitySystem;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;

namespace GameEngine.Rendering._3D
{
    /// <summary>
    /// A mesh holding data for rendering a 3d model.
    /// </summary>
    public class Mesh : IComponent
    {
        /// <summary>
        /// Instantiate a new <see cref="Mesh"/> with a set amount of vertices.
        /// </summary>
        /// <param name="vertexCount">The amount of vertices.</param>
        public Mesh(uint vertexCount)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Instantiate a new <see cref="Mesh"/>.
        /// </summary>
        /// <param name="vertices">The vertices of the mesh.</param>
        /// <param name="indices">The indices of the mesh.</param>
        public Mesh(Vertex[] vertices, uint[] indices)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Load a <see cref="Mesh"/> from the hard drive.
        /// </summary>
        /// <param name="path">The path of the mesh.</param>
        public Mesh(string path)
        {
            throw new NotImplementedException();
        }

        public Vertex this[uint vertex]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// The vertex normals of the mesh.
        /// </summary>
        public Vector4[] Normals { get { throw new NotImplementedException(); } }

        /// <summary>
        /// The vertex positions of the mesh.
        /// </summary>
        public Vector4[] Positions { get { throw new NotImplementedException(); } }

        /// <summary>
        /// The vertex texture coordinates of the mesh.
        /// </summary>
        public Vector2[] TextureCoordinates { get { throw new NotImplementedException(); } }

        /// <summary>
        /// Sets the vertex of a given index.
        /// </summary>
        /// <param name="vertexIndex">The index to set the vertex for.</param>
        /// <param name="vertex">The new vertex at the given index.</param>
        public void SetVertex(uint vertexIndex, Vertex vertex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the vertex position of a given vertex.
        /// </summary>
        /// <param name="vertexIndex">The index of the vertex to set the position for.</param>
        /// <param name="position">The new position of the vertex.</param>
        public void SetPosition(uint vertexIndex, Vector4 position)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the vertex normal of a given vertex.
        /// </summary>
        /// <param name="vertexIndex">The index of the vertex to set the normal for.</param>
        /// <param name="normal">The new normal of the vertex.</param>
        public void SetNormal(uint vertexIndex, Vector4 normal)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the vertex color of a given vertex.
        /// </summary>
        /// <param name="vertexIndex">The index of the vertex to set the color for.</param>
        /// <param name="color">The new color of the vertex.</param>
        public void SetColor(uint vertexIndex, Color color)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets a texture coordinate of a given vertex.
        /// </summary>
        /// <param name="vertexIndex">The index of the vertex to set the texture coordinate for.</param>
        /// <param name="textureCoordinateIndex">The index of the texture coordinate to set.</param>
        /// <param name="textureCoordinate">The new texture coordinate.</param>
        public void SetTextureCoordinate(uint vertexIndex, uint textureCoordinateIndex, Vector2 textureCoordinate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the vertex of a given index.
        /// </summary>
        /// <param name="vertexIndex">The index of the vertex to get.</param>
        /// <returns>The vertex at the given position.</returns>
        public Vertex GetVertex(uint vertexIndex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the position of a given vertex.
        /// </summary>
        /// <param name="vertexIndex">The index of the vertex to get the position for.</param>
        /// <returns>The position of the given vertex.</returns>
        public Vector4 GetPosition(uint vertexIndex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the normal of a given vertex.
        /// </summary>
        /// <param name="vertexIndex">The index of the vertex to get the normal for.</param>
        /// <returns>The normal of the given vertex.</returns>
        public Vector4 GetNormal(uint vertexIndex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the color of a given vertex.
        /// </summary>
        /// <param name="vertexIndex">The index of the vertex to set the color for.</param>
        /// <returns>The color of the given vertex.</returns>
        public Color GetColor(uint vertexIndex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a specific texture coordinate of a given vertex.
        /// </summary>
        /// <param name="vertexIndex">The index of the vertex to get the texture coordinate for.</param>
        /// <param name="textureCoordinateIndex">The index of the texture coordinate to get.</param>
        /// <returns>The specific texture coordinate of the given vertex.</returns>
        public Vector2 GetTextureCoordinate(uint vertexIndex, uint textureCoordinateIndex)
        {
            throw new NotImplementedException();
        }
    }
}
