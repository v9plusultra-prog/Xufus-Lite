using XufusLite.Core.Abstractions;
using XufusLite.Core.Models;

namespace XufusLite.Core;

public sealed class BootUsbOrchestrator(
    IValidationService validator,
    IWriterService writer,
    IVerificationService verifier,
    IAuditLogger logger)
{
    public async Task ExecuteAsync(WritePlan plan, IProgress<double> progress, CancellationToken ct)
    {
        logger.Info($"Validating write plan for {plan.DeviceId}");
        await validator.ValidateWriteRequestAsync(plan, ct);

        logger.Info("Starting secure write phase");
        await writer.WriteAsync(plan, progress, ct);

        if (plan.VerifyAfterWrite)
        {
            logger.Info("Starting verification phase");
            await verifier.VerifyAsync(plan, progress, ct);
        }

        logger.Info("Operation completed successfully");
    }
}
