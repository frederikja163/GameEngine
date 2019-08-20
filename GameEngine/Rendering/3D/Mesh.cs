using GameEngine.EntitySystem;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace GameEngine.Rendering._3D
{
    /// <summary>
    /// A mesh holding data for rendering a 3d model.
    /// </summary>
    public class Mesh : IComponent
    {
        private float[] _vertexData;
        private uint _textureCoordinateCount;
        private uint _vertexCount;

        /// <summary>
        /// Instantiate a new <see cref="Mesh"/>.
        /// </summary>
        /// <param name="positions">The vertex positions of the mesh.</param>
        /// <param name="normals">The vertex normals of the mesh.</param>
        /// <param name="textureCoordinates">The texture coordinates of the mesh.</param>
        public Mesh(Vector4[] positions, Vector4[] normals, params Vector2[] textureCoordinates)
        {
            throw new NotImplementedException();
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
