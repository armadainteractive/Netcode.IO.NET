using System;

using System.Net;
using System.Threading;
using System.Threading.Tasks;
using NetcodeIO.NET;
using Xunit;

using System.Diagnostics;

using NetcodeIO.NET.Tests;

namespace Netcode_IO_Unit_Tests
{
	public class UnitTest1
	{
		[Fact]
		public void TestSequence()
		{
			Tests.TestSequence();
		}

		[Fact]
		public void TestConnectToken()
		{
			Tests.TestConnectToken();
		}

		[Fact]
		public void TestChallengeToken()
		{
			Tests.TestChallengeToken();
		}

		[Fact]
		public void TestEncryptionManager()
		{
			Tests.TestEncryptionManager();
		}

		[Fact]
		public void TestReplayProtection()
		{
			Tests.TestReplayProtection();
		}

		[Fact]
		public void TestConnectionRequestPacket()
		{
			Tests.TestConnectionRequestPacket();
		}

		[Fact]
		public void TestConnectionDeniedPacket()
		{
			Tests.TestConnectionDeniedPacket();
		}

		[Fact]
		public void TestConnectionKeepAlivePacket()
		{
			Tests.TestConnectionKeepAlivePacket();
		}

		[Fact]
		public void TestConnectionChallengePacket()
		{
			Tests.TestConnectionChallengePacket();
		}

		[Fact]
		public void TestConnectionPayloadPacket()
		{
			Tests.TestConnectionPayloadPacket();
		}

		[Fact]
		public void TestConnectionDisconnectPacket()
		{
			Tests.TestConnectionDisconnectPacket();
		}

		[Fact]
		public void TestClientServerConnection()
		{
			Tests.TestClientServerConnection();
		}

		[Fact]
		public void TestClientServerKeepAlive()
		{
			Tests.TestClientServerKeepAlive();
		}

		[Fact]
		public void TestClientServerMultipleClients()
		{
			Tests.TestClientServerMultipleClients();
		}

		[Fact]
		public void TestClientServerMultipleServers()
		{
			Tests.TestClientServerMultipleServers();
		}

		[Fact]
		public void TestConnectTokenExpired()
		{
			Tests.TestConnectTokenExpired();
		}

		[Fact]
		public void TestInvalidConnectToken()
		{
			Tests.TestClientInvalidConnectToken();
		}

		[Fact]
		public void TestConnectionTimeout()
		{
			Tests.TestConnectionTimeout();
		}

		[Fact]
		public void TestChallengeResponseTimeout()
		{
			Tests.TestChallengeResponseTimeout();
		}

		[Fact]
		public void TestConnectionRequestTimeout()
		{
			Tests.TestConnectionRequestTimeout();
		}

		[Fact]
		public void TestConnectionDenied()
		{
			Tests.TestConnectionDenied();
		}

		[Fact]
		public void TestClientSideDisconnect()
		{
			Tests.TestClientSideDisconnect();
		}

		[Fact]
		public void TestServerSideDisconnect()
		{
			Tests.TestServerSideDisconnect();
		}

		[Fact]
		public void TestClientReconnect()
		{
			Tests.TestReconnect();
		}

		[Fact]
		public void SoakConnectionTests()
		{
			// Test for a minute (could run longer but would be bad in unit test scenario)
			const int soakTime = 1000 * 60 * 1;

			Stopwatch sw = new Stopwatch();
			sw.Start();

			int iterations = 0;
			while (sw.ElapsedMilliseconds < soakTime)
			{
				Console.WriteLine("=== RUN " + iterations + " ===");

				Tests.TestClientServerConnection();
				Tests.TestClientServerKeepAlive();
				Tests.TestClientServerKeepAlive();
				Tests.TestClientServerMultipleClients();
				Tests.TestClientServerMultipleServers();
				Tests.TestConnectTokenExpired();
				Tests.TestClientInvalidConnectToken();
				Tests.TestConnectionTimeout();
				Tests.TestChallengeResponseTimeout();
				Tests.TestConnectionRequestTimeout();
				Tests.TestConnectionDenied();
				Tests.TestClientSideDisconnect();
				Tests.TestServerSideDisconnect();
				Tests.TestReconnect();

				iterations++;
			}

			sw.Stop();
		}

		[Fact]
		public void SoakClientServerRandomConnection()
		{
			// Test for a minute (could run longer but would be bad in unit test scenario)
			Tests.SoakTestClientServerConnection(1);
		}
	}
}
