// swallow/report unhandled promise rejections coming from adunit
window.addEventListener('unhandledrejection', function (ev) {
  try {
    // Log for diagnostics (remove in production or send to telemetry)
    console.warn('Unhandled promise rejection (global):', ev.reason);

    // Optionally suppress only the specific adunit payload error
    if (ev.reason && typeof ev.reason === 'object' && /payload/.test(String(ev.reason))) {
      // Prevent default console noisy message in some browsers
      ev.preventDefault?.();
      // optionally send to your server for aggregate telemetry:
      // navigator.sendBeacon('/telemetry/js-error', JSON.stringify({msg: String(ev.reason)}));
    }
  } catch (ex) {
    // swallow any error from the handler itself
  }
});