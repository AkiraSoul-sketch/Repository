namespace Domain.Position
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Domain.LocationContext.ValueObjects;
    using Domain.Position.ValueObject;
    using Domain.Shared;

    /**
         * <summary>
         * Позиция.
         * </summary>
         */
    public class View
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <param name="name">название.</param>
        /// <param name="lifeTime">время жизни.</param>
        /// <param name="description">описание.</param>
        public View(
            PositionId id,
            NotEmptyName name,
            EntityLifeTime lifeTime,
            PositionDescription description
        )
        {
            this.Id = id;
            this.Name = name;
            this.LifeTime = lifeTime;
            this.Description = description;
        }

        /**
         * <summary>
         * Gets Идентификатор позиции.
         * </summary>
         */
        public PositionId Id { get; }

        /// <summary>
        /// Gets не пустое назване места.
        /// </summary>
        public NotEmptyName Name { get; }

        /// <summary>
        /// Gets метаданные о времени жизни сущности.
        /// </summary>
        public EntityLifeTime LifeTime { get; }

        /// <summary>
        /// Gets описание позиции.
        /// </summary>
        public PositionDescription Description { get; }
    }
}
