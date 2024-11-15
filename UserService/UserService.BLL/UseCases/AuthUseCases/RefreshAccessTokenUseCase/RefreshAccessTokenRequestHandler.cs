﻿using MediatR;
using UserService.BLL.Exceptions;
using UserService.DAL.Services.Authentication;

namespace UserService.BLL.UseCases.AuthUseCases.RefreshAccessTokenUseCase;

internal class RefreshAccessTokenRequestHandler(ITokenService tokenService)
    : IRequestHandler<RefreshAccessTokenRequest, string>
{
    public async Task<string> Handle(RefreshAccessTokenRequest request, CancellationToken cancellationToken)
    {
        var token = await tokenService.RefreshAccessTokenAsync(request.refreshToken);

        if(token is null)
        {
            throw new InvalidTokenException("Invalid refresh token");
        }

        return token;
    }
}
