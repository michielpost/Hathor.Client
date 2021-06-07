# Hathor.Client

Client for Hathor Wallet API

## Getting Started

Make sure you have access to the [Hathor Headless Wallet API](https://github.com/HathorNetwork/hathor-wallet-headless). You can use the [hathornetwork/hathor-wallet-headless](https://hub.docker.com/r/hathornetwork/hathor-wallet-headless) docker image.

Start docker image:
```ps
docker pull hathornetwork/hathor-wallet-headless
docker run -p 8000:8000 hathornetwork/hathor-wallet-headless --seed_default "YOUR 24 SEED WORDS"

#Example, do not use:
docker run -p 8000:8000 hathornetwork/hathor-wallet-headless --seed_default "work above economy captain advance bread logic paddle copper change maze tongue salon sadness cannon fish debris need make purpose usage worth vault shrug"
```
The Hathor Headless Wallet API is now available on `http://localhost:8000`