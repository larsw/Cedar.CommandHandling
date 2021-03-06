﻿namespace Cedar.CommandHandling
{
    using System;
    using System.Net;
    using Cedar.CommandHandling.Http;
    using Shouldly;
    using Xunit;

    public class HttpProblemDetailsTests
    {
        [Fact]
        public void Can_create_exception_with_status_code()
        {
            var sut = new HttpProblemDetails { Status = (int)HttpStatusCode.BadRequest };

            sut.Status.ShouldBe((int)HttpStatusCode.BadRequest);
        }

        [Fact]
        public void When_setting_type_with_a_relative_uri_should_throw()
        {
            var sut = new HttpProblemDetails { Status = (int)HttpStatusCode.BadRequest };

            Action act = () => sut.Type = "/relative";

            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void When_setting_instance_with_a_relative_uri_should_throw()
        {
            var sut = new HttpProblemDetails { Status = (int)HttpStatusCode.BadRequest };

            Action act = () => sut.Instance = "/relative";

            act.ShouldThrow<InvalidOperationException>();
        }
    }
}