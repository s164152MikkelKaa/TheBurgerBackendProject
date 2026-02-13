namespace TheBurgerBackendProject.DTOs
{
    public class DataContainerDTO<T>
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
        public T? Data { get; set; }


        /// <summary>
        /// Factory pattern for a successfull type response containing data.
        /// Meant as an API message wrapper, can be used internally in the program (adds overhead).
        /// </summary>
        /// <param name="data">Data being send.</param>
        /// <returns>A datawrapper indicating a success and containing the data.</returns>
        public static DataContainerDTO<T> SuccessResponse(T data)
        {
            return new DataContainerDTO<T>
            {
                Success = true,
                Data = data
            };
        }

        /// <summary>
        /// Factory pattern for a failed type response with an error message.
        /// Meant as an API message wrapper, can be used internally in the program (adds overhead).
        /// </summary>
        /// <param name="errorMessage">Custom error message.</param>
        /// <returns>A datawrapper indicating a failure and containing an error message.</returns>
        public static DataContainerDTO<T> ErrorResponse(string errorMessage)
        {
            return new DataContainerDTO<T>
            {
                Success = false,
                ErrorMessage = errorMessage
            };
        }

        /// <summary>
        /// Factory pattern for a successfull type response containing no data.
        /// Meant as an API message wrapper, can be used internally in the program (adds overhead).
        /// </summary>
        /// <returns>A datawrapper indicating a success.</returns>
        public static DataContainerDTO<T> SuccessResponse()
        {
            return new DataContainerDTO<T>
            {
                Success = true
            };
        }

        /// <summary>
        /// Factory pattern for a failed type response with an error message.
        /// Meant as an API message wrapper, can be used internally in the program (adds overhead).
        /// </summary>
        /// <param name="theException">The exception causing the error.</param>
        /// <returns>A datawrapper indicating a failure and containing a standart error message.</returns>
        public static DataContainerDTO<T> ErrorResponse(Exception theException)
        {
            return new DataContainerDTO<T>
            {
                Success = false,
                ErrorMessage = theException.Message
            };
        }
    }

    /*public class DataContainerDTO
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }

        public static DataContainerDTO SuccessResponse()
        {
            return new DataContainerDTO
            {
                Success = true
            };
        }

        public static DataContainerDTO ErrorResponse(string errorMessage)
        {
            return new DataContainerDTO
            {
                Success = false,
                ErrorMessage = errorMessage
            };
        }

        public static DataContainerDTO ErrorResponse()
        {
            return new DataContainerDTO
            {
                Success = false
            };
        }
    }// */
}
